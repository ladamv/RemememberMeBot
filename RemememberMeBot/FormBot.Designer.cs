namespace RemememberMeBot
{
    partial class FormBot
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartBot = new System.Windows.Forms.Button();
            this.buttonStopBot = new System.Windows.Forms.Button();
            this.backgroundWorkerBot = new System.ComponentModel.BackgroundWorker();
            this.buttonStartDictionary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartBot
            // 
            this.buttonStartBot.Location = new System.Drawing.Point(12, 28);
            this.buttonStartBot.Name = "buttonStartBot";
            this.buttonStartBot.Size = new System.Drawing.Size(127, 83);
            this.buttonStartBot.TabIndex = 0;
            this.buttonStartBot.Text = "StartBot";
            this.buttonStartBot.UseVisualStyleBackColor = true;
            this.buttonStartBot.Click += new System.EventHandler(this.buttonStartBot_Click);
            // 
            // buttonStopBot
            // 
            this.buttonStopBot.Location = new System.Drawing.Point(168, 28);
            this.buttonStopBot.Name = "buttonStopBot";
            this.buttonStopBot.Size = new System.Drawing.Size(127, 83);
            this.buttonStopBot.TabIndex = 1;
            this.buttonStopBot.Text = "StopBot";
            this.buttonStopBot.UseVisualStyleBackColor = true;
            this.buttonStopBot.Click += new System.EventHandler(this.buttonStopBot_Click);
            // 
            // backgroundWorkerBot
            // 
            this.backgroundWorkerBot.WorkerReportsProgress = true;
            this.backgroundWorkerBot.WorkerSupportsCancellation = true;
            this.backgroundWorkerBot.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBot_DoWork);
            // 
            // buttonStartDictionary
            // 
            this.buttonStartDictionary.Location = new System.Drawing.Point(321, 28);
            this.buttonStartDictionary.Name = "buttonStartDictionary";
            this.buttonStartDictionary.Size = new System.Drawing.Size(127, 83);
            this.buttonStartDictionary.TabIndex = 2;
            this.buttonStartDictionary.Text = "Управление словарём";
            this.buttonStartDictionary.UseVisualStyleBackColor = true;
            this.buttonStartDictionary.Click += new System.EventHandler(this.buttonStartDictionary_Click);
            // 
            // FormBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 123);
            this.Controls.Add(this.buttonStartDictionary);
            this.Controls.Add(this.buttonStopBot);
            this.Controls.Add(this.buttonStartBot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBot";
            this.Text = "FormBot";
            this.Load += new System.EventHandler(this.FormBot_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartBot;
        private System.Windows.Forms.Button buttonStopBot;
        private System.ComponentModel.BackgroundWorker backgroundWorkerBot;
        private System.Windows.Forms.Button buttonStartDictionary;
    }
}

