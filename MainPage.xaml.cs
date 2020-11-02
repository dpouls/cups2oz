using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CupsToOz
{
    public partial class MainPage : ContentPage
    {
        // define constant for cups to oz, factor that converts it.
        const int CUPS_TO_OZ = 8;
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Converts cups to ounces after validating input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvert_Clicked(object sender, EventArgs e)
        {
            // create variables for cups and ounces to use later
            double cups = 0, ounces = 0;
            //check if cups are valid using the ValidCups method.
            if (ValidCups(ref cups))
            {
                //cups are valid so we assign the amount of cups from the input to our CalculateOz function and assign the result to ounces
                ounces = CalculateOz(cups);
                //display the results using DisplayResults method and the ounces we returned.
                DisplayResults(ounces);
            }

        }
        /// <summary>
        /// Displays results by changing label text
        /// </summary>
        /// <param name="ounces"></param>
        private void DisplayResults(double ounces)
        {
            //change text for lblresults to the ounces passed in
            LblResults.Text = ounces.ToString("N2");
        }
        /// <summary>
        /// calculates the oz from the cups input
        /// </summary>
        /// <param name="cups"></param>
        /// <returns></returns>
        private double CalculateOz(double cups)
        {
            //multiplies cups input by the constant CUPS_TO_OZ and returns the result.
            return cups * CUPS_TO_OZ;
        }
        /// <summary>
        /// Checks if valid input was passed into the entry
        /// </summary>
        /// <param name="cups"></param>
        /// <returns></returns>
        private bool ValidCups(ref double cups)
        {
            //if statement to check if the input was numeric, if so, return true and cups
            if (double.TryParse(EntryCups.Text, out cups)) return true;
            //if false the method continues and hits our alert
                DisplayAlert("Invalid Input", "Please enter a number for cups", "Close");
            //and also returns false so the user can't move forward.
            return false;
        }
    }
}
