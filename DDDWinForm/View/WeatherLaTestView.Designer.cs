﻿namespace DDDWinForm
{
    partial class WeatherLaTestView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DateTime = new System.Windows.Forms.Label();
            this.Condition = new System.Windows.Forms.Label();
            this.Temperature = new System.Windows.Forms.Label();
            this.LatestButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AreaComboBox = new System.Windows.Forms.ComboBox();
            this.WeatherList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "地域";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "日時";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "状態";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "温度";
            // 
            // DateTime
            // 
            this.DateTime.AutoSize = true;
            this.DateTime.Location = new System.Drawing.Point(104, 91);
            this.DateTime.Name = "DateTime";
            this.DateTime.Size = new System.Drawing.Size(43, 15);
            this.DateTime.TabIndex = 4;
            this.DateTime.Text = "label5";
            // 
            // Condition
            // 
            this.Condition.AutoSize = true;
            this.Condition.Location = new System.Drawing.Point(104, 124);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(43, 15);
            this.Condition.TabIndex = 5;
            this.Condition.Text = "label6";
            // 
            // Temperature
            // 
            this.Temperature.AutoSize = true;
            this.Temperature.Location = new System.Drawing.Point(104, 157);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(43, 15);
            this.Temperature.TabIndex = 6;
            this.Temperature.Text = "label7";
            // 
            // LatestButton
            // 
            this.LatestButton.Location = new System.Drawing.Point(241, 63);
            this.LatestButton.Name = "LatestButton";
            this.LatestButton.Size = new System.Drawing.Size(75, 23);
            this.LatestButton.TabIndex = 8;
            this.LatestButton.Text = "直近値";
            this.LatestButton.UseVisualStyleBackColor = true;
            this.LatestButton.Click += new System.EventHandler(this.LatestButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(107, 12);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 9;
            this.UpdateButton.Text = "更新";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AreaComboBox
            // 
            this.AreaComboBox.FormattingEnabled = true;
            this.AreaComboBox.Location = new System.Drawing.Point(107, 60);
            this.AreaComboBox.Name = "AreaComboBox";
            this.AreaComboBox.Size = new System.Drawing.Size(121, 23);
            this.AreaComboBox.TabIndex = 10;
            // 
            // WeatherList
            // 
            this.WeatherList.Location = new System.Drawing.Point(26, 12);
            this.WeatherList.Name = "WeatherList";
            this.WeatherList.Size = new System.Drawing.Size(75, 23);
            this.WeatherList.TabIndex = 11;
            this.WeatherList.Text = "一覧";
            this.WeatherList.UseVisualStyleBackColor = true;
            this.WeatherList.Click += new System.EventHandler(this.WeatherList_Click);
            // 
            // WeatherLaTestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 270);
            this.Controls.Add(this.WeatherList);
            this.Controls.Add(this.AreaComboBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.LatestButton);
            this.Controls.Add(this.Temperature);
            this.Controls.Add(this.Condition);
            this.Controls.Add(this.DateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WeatherLaTestView";
            this.Text = "Weather Latest View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label DateTime;
        private System.Windows.Forms.Label Condition;
        private System.Windows.Forms.Label Temperature;
        private System.Windows.Forms.Button LatestButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ComboBox AreaComboBox;
        private System.Windows.Forms.Button WeatherList;
    }
}

