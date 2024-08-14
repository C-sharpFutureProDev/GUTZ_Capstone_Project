using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GUTZ_Capstone_Project
{
    internal class User_InputsValidatorHelperClass
    {
        /// <summary>
        /// Validates the user input in a Guna TextBox field.
        /// </summary>
        /// <param name="textBox">The Guna TextBox to be validated.</param>
        /// <param name="fieldTitle">The title of the field being validated.</param>
        /// <returns>True if the input is valid, false otherwise.</returns>
        public static bool ValidateGunaTextBoxInput(Guna2TextBox textBox, string fieldTitle)
        {
            // Check if the text box is null or empty
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"Please enter a value for the {fieldTitle} field.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the user input in a Guna TextBox field as a number.
        /// </summary>
        /// <param name="textBox">The Guna TextBox to be validated.</param>
        /// <param name="fieldTitle">The title of the field being validated.</param>
        /// <returns>True if the input is a valid number, false otherwise.</returns>
        public static bool ValidateGunaTextBoxAsNumber(Guna2TextBox textBox, string fieldTitle)
        {
            // Validate the input as a number
            if (!int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show($"The {fieldTitle} field must be a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the user's gender selection using radio buttons.
        /// </summary>
        /// <param name="maleRadioButton">The male radio button control.</param>
        /// <param name="femaleRadioButton">The female radio button control.</param>
        /// <returns>True if a gender is selected, false otherwise.</returns>
        public static bool ValidateGenderSelection(RadioButton maleRadioButton, RadioButton femaleRadioButton)
        {
            // Check if either the male or female radio button is selected
            if (!maleRadioButton.Checked && !femaleRadioButton.Checked)
            {
                MessageBox.Show("Please select a gender.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the email input format.
        /// </summary>
        /// <param name="emailTextBox">The Guna TextBox containing the email input.</param>
        /// <returns>True if the email format is valid, false otherwise.</returns>
        public static bool ValidateEmailFormat(Guna2TextBox emailTextBox)
        {
            // Define a regular expression pattern to match valid email format
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            // Check if the email input matches the pattern
            if (!Regex.IsMatch(emailTextBox.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTextBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the employee profile picture input.
        /// </summary>
        /// <param name="profilePictureData">The byte array containing the profile picture data.</param>
        /// <returns>True if a picture is selected, false otherwise.</returns>
        public static bool ValidateProfilePicture(byte[] profilePictureData)
        {
            // Check if a picture has been selected
            if (profilePictureData == null || profilePictureData.Length == 0)
            {
                MessageBox.Show("Please select an employee profile picture.", "No Picture Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Previous methods omitted for brevity

        /// <summary>
        /// Validates the Guna ComboBox input.
        /// </summary>
        /// <param name="comboBox">The Guna ComboBox control to be validated.</param>
        /// <param name="fieldName">The name of the field represented by the ComboBox.</param>
        /// <returns>True if a valid selection is made, false otherwise.</returns>
        public static bool ValidateGunaComboBoxSelection(Guna2ComboBox comboBox, string fieldName)
        {
            // Check if a valid selection is made
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show($"Please select a value for the {fieldName} field.", "No Selection Made", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the employee fingerprint picture input.
        /// </summary>
        /// <param name="fingerprintPictureData">The byte array containing the fingerprint picture data.</param>
        /// <returns>True if a picture is selected, false otherwise.</returns>
        public static bool ValidateFingerprintPicture(byte[] fingerprintPictureData)
        {
            // Check if a picture has been selected
            if (fingerprintPictureData == null || fingerprintPictureData.Length == 0)
            {
                MessageBox.Show("Please do the Fingerprint Enrollment Process.", "No Fingerprint Enrollment Process Yet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}