namespace DDDWinForm.View
{
    partial class WeatherListView
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
            this.WeatherListDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WeatherListDataGridView
            // 
            this.WeatherListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeatherListDataGridView.Location = new System.Drawing.Point(0, -1);
            this.WeatherListDataGridView.Name = "WeatherListDataGridView";
            this.WeatherListDataGridView.ReadOnly = true;
            this.WeatherListDataGridView.RowHeadersWidth = 51;
            this.WeatherListDataGridView.RowTemplate.Height = 24;
            this.WeatherListDataGridView.Size = new System.Drawing.Size(698, 299);
            this.WeatherListDataGridView.TabIndex = 0;
            // 
            // WeatherListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 301);
            this.Controls.Add(this.WeatherListDataGridView);
            this.Name = "WeatherListView";
            this.Text = "WeatherListView";
            ((System.ComponentModel.ISupportInitialize)(this.WeatherListDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeatherListDataGridView;
    }
}