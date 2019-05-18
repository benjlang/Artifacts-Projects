namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxCold = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxTreats = new System.Windows.Forms.CheckedListBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.HotDrinkDecaff = new System.Windows.Forms.Label();
            this.ColdDrinkLabel = new System.Windows.Forms.Label();
            this.TreatsLabel = new System.Windows.Forms.Label();
            this.Review = new System.Windows.Forms.Label();
            this.HotCaff = new System.Windows.Forms.Label();
            this.CheckedListBoxHotCaff = new System.Windows.Forms.CheckedListBox();
            this.CheckedListBoxHotCaffe = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxCold
            // 
            this.checkedListBoxCold.CheckOnClick = true;
            this.checkedListBoxCold.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.checkedListBoxCold.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkedListBoxCold.FormattingEnabled = true;
            this.checkedListBoxCold.Items.AddRange(new object[] {
            "Blue Jolly Rancher",
            "Grape",
            "Hawaiian Punch",
            "Country Time Lemonade",
            "Lipton Lemon Iced Tea",
            "TANG"});
            this.checkedListBoxCold.Location = new System.Drawing.Point(711, 135);
            this.checkedListBoxCold.Name = "checkedListBoxCold";
            this.checkedListBoxCold.Size = new System.Drawing.Size(246, 340);
            this.checkedListBoxCold.TabIndex = 3;
            this.checkedListBoxCold.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxCold_SelectedIndexChanged);
            // 
            // checkedListBoxTreats
            // 
            this.checkedListBoxTreats.CheckOnClick = true;
            this.checkedListBoxTreats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.checkedListBoxTreats.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkedListBoxTreats.FormattingEnabled = true;
            this.checkedListBoxTreats.Items.AddRange(new object[] {
            "Oreo Cookie Bars",
            "Chocolate Rice Crispies",
            "Fruity Pebbles Rice Crispies",
            "Party Bars",
            "Mint chip brownies",
            "Triple Chocolate Brownie",
            "Sugar Cookie Bars",
            "Ashley\'s Fabulous Cookies",
            "Zesty Pretzels",
            "Sweet & Savory Pretzels",
            "Home-Baked Muffins (large)"});
            this.checkedListBoxTreats.Location = new System.Drawing.Point(1038, 135);
            this.checkedListBoxTreats.Name = "checkedListBoxTreats";
            this.checkedListBoxTreats.Size = new System.Drawing.Size(272, 340);
            this.checkedListBoxTreats.TabIndex = 4;
            this.checkedListBoxTreats.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTreats_SelectedIndexChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.Gold;
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SubmitButton.Location = new System.Drawing.Point(593, 505);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(169, 54);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.Title.Location = new System.Drawing.Point(479, 31);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(387, 37);
            this.Title.TabIndex = 6;
            this.Title.Text = "Jo-2-Go Menu Application";
            this.Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // HotDrinkDecaff
            // 
            this.HotDrinkDecaff.AutoSize = true;
            this.HotDrinkDecaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.HotDrinkDecaff.Location = new System.Drawing.Point(28, 96);
            this.HotDrinkDecaff.Name = "HotDrinkDecaff";
            this.HotDrinkDecaff.Size = new System.Drawing.Size(215, 24);
            this.HotDrinkDecaff.TabIndex = 7;
            this.HotDrinkDecaff.Text = "Hot Drinks Decaffeinated";
            // 
            // ColdDrinkLabel
            // 
            this.ColdDrinkLabel.AutoSize = true;
            this.ColdDrinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ColdDrinkLabel.Location = new System.Drawing.Point(707, 96);
            this.ColdDrinkLabel.Name = "ColdDrinkLabel";
            this.ColdDrinkLabel.Size = new System.Drawing.Size(106, 24);
            this.ColdDrinkLabel.TabIndex = 8;
            this.ColdDrinkLabel.Text = "Cold Drinks";
            // 
            // TreatsLabel
            // 
            this.TreatsLabel.AutoSize = true;
            this.TreatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TreatsLabel.Location = new System.Drawing.Point(1034, 96);
            this.TreatsLabel.Name = "TreatsLabel";
            this.TreatsLabel.Size = new System.Drawing.Size(62, 24);
            this.TreatsLabel.TabIndex = 9;
            this.TreatsLabel.Text = "Treats";
            // 
            // Review
            // 
            this.Review.AutoSize = true;
            this.Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Review.Location = new System.Drawing.Point(846, 520);
            this.Review.Name = "Review";
            this.Review.Size = new System.Drawing.Size(0, 24);
            this.Review.TabIndex = 10;
            // 
            // HotCaff
            // 
            this.HotCaff.AutoSize = true;
            this.HotCaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.HotCaff.Location = new System.Drawing.Point(350, 96);
            this.HotCaff.Name = "HotCaff";
            this.HotCaff.Size = new System.Drawing.Size(194, 24);
            this.HotCaff.TabIndex = 12;
            this.HotCaff.Text = "Hot Drinks Caffeinated";
            this.HotCaff.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // CheckedListBoxHotCaff
            // 
            this.CheckedListBoxHotCaff.CheckOnClick = true;
            this.CheckedListBoxHotCaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.CheckedListBoxHotCaff.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CheckedListBoxHotCaff.FormattingEnabled = true;
            this.CheckedListBoxHotCaff.Items.AddRange(new object[] {
            "Streusel Cake",
            "Chocolate Caramel Brownie",
            "French Caramel Cream",
            "Sinful Delight",
            "Vanilla",
            "Vanilla Hazelnut",
            "Hazelnut",
            "Highlander Grogg",
            "Hot Chocolate"});
            this.CheckedListBoxHotCaff.Location = new System.Drawing.Point(32, 135);
            this.CheckedListBoxHotCaff.Name = "CheckedListBoxHotCaff";
            this.CheckedListBoxHotCaff.Size = new System.Drawing.Size(262, 340);
            this.CheckedListBoxHotCaff.TabIndex = 15;
            this.CheckedListBoxHotCaff.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxHotCaff_SelectedIndexChanged);
            // 
            // CheckedListBoxHotCaffe
            // 
            this.CheckedListBoxHotCaffe.CheckOnClick = true;
            this.CheckedListBoxHotCaffe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.CheckedListBoxHotCaffe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CheckedListBoxHotCaffe.FormattingEnabled = true;
            this.CheckedListBoxHotCaffe.Items.AddRange(new object[] {
            "Southern Toasted Pecan",
            "Breakfast Blend",
            "Chai Tea",
            "French Vanilla Cappiccino",
            "English Toffee Cappiccino",
            "Cinnanut Island",
            "Chocolate Caramel Brownie",
            "Buttered Rum",
            "French Vanilla Almond",
            "Hazelnut",
            "Vanilla Hazella",
            "French Caramel Cream",
            "Highland Grogg",
            "White Russian",
            "Vanilla Nut",
            "Packer Perc",
            "Mudslide"});
            this.CheckedListBoxHotCaffe.Location = new System.Drawing.Point(354, 135);
            this.CheckedListBoxHotCaffe.Name = "CheckedListBoxHotCaffe";
            this.CheckedListBoxHotCaffe.Size = new System.Drawing.Size(280, 340);
            this.CheckedListBoxHotCaffe.TabIndex = 16;
            this.CheckedListBoxHotCaffe.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxHotCaffe_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1370, 586);
            this.Controls.Add(this.CheckedListBoxHotCaffe);
            this.Controls.Add(this.CheckedListBoxHotCaff);
            this.Controls.Add(this.HotCaff);
            this.Controls.Add(this.Review);
            this.Controls.Add(this.TreatsLabel);
            this.Controls.Add(this.ColdDrinkLabel);
            this.Controls.Add(this.HotDrinkDecaff);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.checkedListBoxTreats);
            this.Controls.Add(this.checkedListBoxCold);
            this.Name = "Form1";
            this.Text = "Jo2Go Application Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBoxCold;
        private System.Windows.Forms.CheckedListBox checkedListBoxTreats;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label HotDrinkDecaff;
        private System.Windows.Forms.Label ColdDrinkLabel;
        private System.Windows.Forms.Label TreatsLabel;
        private System.Windows.Forms.Label Review;
        private System.Windows.Forms.Label HotCaff;
        private System.Windows.Forms.CheckedListBox CheckedListBoxHotCaff;
        private System.Windows.Forms.CheckedListBox CheckedListBoxHotCaffe;
    }
}

