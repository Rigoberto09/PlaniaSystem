using System.Globalization;
using System.Runtime.CompilerServices;

namespace SistemaPlania.Client.Pages
{
    public partial class Deducciones
    {
        #region variables locales
        private Drink enumValue { get; set; } = Drink.HotWater;
        public enum Drink { Tea, SparklingWater, SoftDrink, Cider, Beer, Wine, Moonshine, Wodka, Cola, GreeTea, FruitJuice, Lemonade, HotWater, SpringWater, IceWater, }
        public decimal DecimalValue { get; set; }

        private Decimal monto { get; set; }
        #endregion

        private void sumar()
        {
            this.monto+=this.monto;
        }

    }
}
