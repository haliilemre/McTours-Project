using McTours.Common;
using System.Text;

namespace McTours
{
    public static class EnumHelper
    {
        #region FuelTypeHelper
        public static readonly Dictionary<FuelType, string> FuelNames = new Dictionary<FuelType, string>()
        {
            [FuelType.Diesel] = "Dizel",
            [FuelType.Gasoline] = "Benzinli",
            [FuelType.Electrical] = "Elektrikli",
            [FuelType.Hybrid] = "Hibrit"
        };

        public static IEnumerable<ValueNameObject> FuelTypesGetAll()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in FuelNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }
        #endregion

        #region SeatingTypeHelper
        public static readonly Dictionary<SeatingType, string> SeatingTypeNames = new Dictionary<SeatingType, string>()
        {
            [SeatingType.Standard] = "Standart",
            [SeatingType.Deluxe] = "Lüks",
            [SeatingType.Vip] = "Vip",
        };

        public static IEnumerable<ValueNameObject> SeatingTypesGetAll()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in SeatingTypeNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }
        #endregion

        #region UtilityHelper

        public static readonly Dictionary<Utility, string> UtilityNames = new Dictionary<Utility, string>()
        {
            [Utility.FoodService] = "Yiyecek servisi",
            [Utility.Wifi] = "Kablosuz internet",
            [Utility.PowerOutlet] = "Koltuklarda priz",
            [Utility.UsbCharge] = "USB girişi",
            [Utility.Tv] = "Televizyon",
            [Utility.Radio] = "Radyo",
            [Utility.Headset] = "Kulaklık",
            [Utility.Toilet] = "Lavabo"
        };

        public static IEnumerable<ValueNameObject> UtilityGetAll()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in UtilityNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }

        public static string GetNames(this Utility utilities)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in UtilityNames)
            {
                if (utilities.HasFlag(item.Key))
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(item.Value);
                }
            }

            return stringBuilder.ToString();
        }



        #endregion

        #region GenderHelper
        public static readonly Dictionary<Gender, string> GenderNames = new Dictionary<Gender, string>()
        {
            //[Gender.None] = "-",
            [Gender.Female] = "Kadın",
            [Gender.Male] = "Erkek",
        };

        public static IEnumerable<ValueNameObject> GendersGetAll()
        {
            var all = new List<ValueNameObject>();

            foreach (var item in GenderNames)
            {
                all.Add(new ValueNameObject()
                {
                    Value = (int)item.Key,
                    Name = item.Value
                });
            }
            return all;
        }

        public static string GetGenderName(this Gender gender)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in GenderNames)
            {
                if (gender.HasFlag(item.Key))
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(item.Value);
                }
            }

            return stringBuilder.ToString();
        }
        #endregion
    }
}
