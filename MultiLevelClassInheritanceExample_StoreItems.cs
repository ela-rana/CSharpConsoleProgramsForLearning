//Coded using C# Console App on .NET Framework 4.8 on Visual Studio 2022
//This is a standalone class file to demonstrate a multilevel class Inheritance
//This code is not being called by a Main function thus it will not do anything if you run this code
using System;

namespace MultiLevelClassInheritanceExample_StoreItems
{
    abstract class Item
    {
        public int ItemId { get; set; } //item id
        public string Name { get; set; }    //item name
        public string Description { get; set; }    //detailed item description
        public string BrandName { get; set; }   //Company or brand name of item
        public double Price { get; set; }   //to set item's original price
        public string UnitOfMeasure { get; set; }   //to hold the unit of measure per item,
                                                    //Ex: pack, 8FL oz. bottle, EA, carton, etc.

        /// <summary>
        /// Default version of the SalePrice method. 
        /// It returns the original price as the SalePrice when no discount parameters are entered
        /// to mean that no discount is available at the moment
        /// </summary>
        /// <returns>sale price which is same as original price when no discount has been entered</returns>
        public virtual double SalePrice()
        {
            return Price;
        }

        /// <summary>
        /// SalePrice method with discount rate entered as parameter
        /// It calculates and returns a discounted price as the SalePrice when a discount rate is entered as a parameter
        /// </summary>
        /// <param name="discount">Any current discount that is available for item in decimal form</param>
        /// <returns>Discounted Sale Price</returns>
        public virtual double SalePrice(double discount)
        {
            return Price * discount;
        }
    }

    class PerishableItem : Item
    {
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// The Sale Price of a perishable item when no discount is entered as a parameter
        /// </summary>
        /// <returns>The original price as Sale Price if item is not expiring soon OR 
        /// returns a 50% discounted price of item expires within the next 5 days</returns>
        public override double SalePrice()
        {
            TimeSpan span = ExpirationDate.Subtract(DateTime.Now);  //holds the value of expiration date - today's date
            if (span.Days<5)    //to check the number of days portion in the difference between the dates
            {
                return Price * .5;
                //to give 50% discount if item is expiring soon (within the next 5 days or already expired) so that we can sell it faster
            }
            else
            {
                return Price;   //no discount if not expiring soon/ already expired
            }
        }

        /// <summary>
        /// The Sale Price of a perishable item with discount added when discount is entered as a parameter
        /// </summary>
        /// <param name="discount"></param>
        /// <returns>User entered discount is applied on regular items. 
        /// For items expiring within the next 5 days either 50% or user entered discount, whichever is bigger is applied to price</returns>
        public override double SalePrice(double discount)
        {
            TimeSpan span = ExpirationDate.Subtract(DateTime.Now);  //holds the value of expiration date - today's date
            if (span.Days < 5 && discount < .50)    //to check the number of days portion in the difference between the dates  
            {
                return Price * .5;
                //to give 50% discount if item is expiring soon/expired so that we can sell it faster
                //but only if 50% is a bigger discount than the user entered discount
            }
            else
            {
                return Price*discount;   //if user entered discount is higher than 50% then the
                                         //sale price will use the user entered discount instead of 50%
            }
        }
    }

    class NonPerishableItem : Item
    {
        public bool HasSecurityTag { get; set; }
        public bool IsElectric { get; set; }
        public bool IsBatteryOperated { get; set; }
    }

    class Medicine : PerishableItem
    {
        public bool isOTC { get; set; } //to check if item is over the counter or if it needs prescription

        /// <summary>
        /// Prescription medications have to have prescriptions verified otherwise they cannot be sold. 
        /// This bool is to ensure prescription has been verified by a pharmacist
        /// </summary>
        /// <returns>true for prescription has been verified as valid or false if it has not</returns>
        public bool PrescriptionGood() 
        {
            if (isOTC == true)
            {
                return true;
            }
            else
            {
                char validated;
                bool flag;
                Console.WriteLine("Has the pharmacist checked the prescription for validity?");
                Console.Write("Enter Y or y for yes or any other single non-blank character for no:  ");
                flag = Char.TryParse(Console.ReadLine(),out validated);
                if ((validated == 'y' || validated == 'Y') && flag==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    class Food:PerishableItem
    {
        public bool isRefrigerated { get; set; } //to check if item needs to be placed in the refrigerated aisle or not
        public bool isOrganic { get; set; } //to check if item need to be stamped with the purple "Organic" sticker or not

    }

    class Makeup:PerishableItem
    {
        public int colorID{ get; set; } //to save makeup item colors for sorting and organzing item display

        public string colorName { get; set; } //to hold a makeup item's color or shade for palette organization,
                                              //such as grouping makeup by the skintone for ease of customer's search

    }

    class Clothing:NonPerishableItem
    {
        /// <summary>
        /// The date at which the season for this clothing started. 
        /// Ex: Spring 2022 could have a date of April 1 2022 entered or Fall 2021 could have a date of 10/01/2021 entered
        /// Season date must be entered in correct format. MM/DD/YYYY  or MM/DD/YYYY HH:MM:SS format is preferred
        /// </summary>
        public DateTime Season { get; set; }       

        /// <summary>
        /// The Sale Price of a clothing item when no discount is entered as a parameter
        /// </summary>
        /// <returns>The original price as Sale Price if item is of the current season OR 
        /// returns a 30% discounted price of item if it is from a fashion season from 5 months or earlier</returns>
        public override double SalePrice()
        {
            TimeSpan span = DateTime.Now.Subtract(Season);  //holds the value of season date - today's date
            if (span.Days > 150)    //to check if the season date was more than 150 days ago (roughly 5 months)
            {
                return Price * .3;
                //to give 30% discount if clothing item is from past season (more than 5 months ago)
            }
            else
            {
                return Price;   //no discount if current season clothes
            }
        }

        /// <summary>
        /// The Sale Price of a clothing item with discount added when discount is entered as a parameter
        /// </summary>
        /// <param name="discount"></param>
        /// <returns>User entered discount is applied on regular items. 
        /// For items from a fashion season from 5 months or earlier, either 30% or user entered discount, whichever is bigger is applied to price</returns>
        public override double SalePrice(double discount)
        {
            TimeSpan span = DateTime.Now.Subtract(Season);  //holds the value of season date - today's date
            if (span.Days > 150 && discount < .30)
            {
                return Price * .3;
                //to give 30% discount if item is clothing item is from past season (more than 5 months ago)
                //so that we can make room for new seasonal clothes
                //but only if 30% is a bigger discount than the user entered discount
            }
            else
            {
                return Price * discount;   //if user entered discount is higher than 30% then the
                                           //sale price will use the user entered discount instead of 30%
            }
        }

    }

    class Toys:NonPerishableItem
    {
        /// <summary>
        /// Holds the age-group that the toy is catered for, Ex: 0-1yr, 1-2 yrs, toddlers, 0-5 yrs, etc. 
        /// </summary>
        public string AgeGroup { get; set; }
    }
}
