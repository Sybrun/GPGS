using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance { set; get; }
    GoldManager Script_GoldManager;
    SaveProgress Script_SaveProgress;

    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

    public static string PRODUCT_1000_GOLD = "gold1000";
    public static string PRODUCT_3500_GOLD = "gold3500";
    public static string PRODUCT_5700_GOLD = "gold5700";
    public static string PRODUCT_NO_ADS = "noads";

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Script_GoldManager = GetComponent<GoldManager>();
        Script_SaveProgress = GetComponent<SaveProgress>();

        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }
    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(PRODUCT_1000_GOLD, ProductType.Consumable);
        builder.AddProduct(PRODUCT_3500_GOLD, ProductType.Consumable);
        builder.AddProduct(PRODUCT_5700_GOLD, ProductType.Consumable);
        builder.AddProduct(PRODUCT_NO_ADS, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }
    private bool IsInitialized()
    {
        // Only say we are initialized if both the Purchasing references are set.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void Buy1000Gold()
    {
        BuyProductID(PRODUCT_1000_GOLD);
    }
    public void Buy3500Gold()
    {
        BuyProductID(PRODUCT_3500_GOLD);
    }
    public void Buy5700Gold()
    {
        BuyProductID(PRODUCT_5700_GOLD);
    }
    public void BuyNoAds()
    {
        BuyProductID(PRODUCT_NO_ADS);
    }

    private void BuyProductID(string productId)
    {
        // If Purchasing has been initialized ...
        if (IsInitialized())
        {
            // ... look up the Product reference with the general product identifier and the Purchasing 
            // system's products collection.
            Product product = m_StoreController.products.WithID(productId);

            // If the look up found a product for this device's store and that product is ready to be sold ... 
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                // asynchronously.
                m_StoreController.InitiatePurchase(product);
            }
            // Otherwise ...
            else
            {
                // ... report the product look-up failure situation  
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        // Otherwise ...
        else
        {
            // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
            // retrying initiailization.
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1000_GOLD, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 1000 Gold!");
            Script_GoldManager.addGold(1000);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_3500_GOLD, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 3500 Gold!");
            Script_GoldManager.addGold(3500);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_5700_GOLD, StringComparison.Ordinal))
        {
            Debug.Log("You've just bought 5700 Gold!");
            Script_GoldManager.addGold(5700);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_NO_ADS, StringComparison.Ordinal))
        {
            Debug.Log("You removed all ads!");
            Script_SaveProgress.activeAds = "false";
            PlayerPrefs.SetString("ActiveAds", Script_SaveProgress.activeAds);
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}

