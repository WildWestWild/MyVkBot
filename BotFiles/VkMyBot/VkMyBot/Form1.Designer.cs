namespace VkMyBot
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.listFriends = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGetMess = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listFriends
            // 
            this.listFriends.FormattingEnabled = true;
            this.listFriends.ItemHeight = 16;
            this.listFriends.Location = new System.Drawing.Point(12, 12);
            this.listFriends.Name = "listFriends";
            this.listFriends.Size = new System.Drawing.Size(203, 420);
            this.listFriends.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(232, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(691, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите сообщение, которое хотите отправить, обратите внимание, имя будет указано" +
    " автоматически!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxGetMess
            // 
            this.textBoxGetMess.Location = new System.Drawing.Point(235, 84);
            this.textBoxGetMess.Name = "textBoxGetMess";
            this.textBoxGetMess.Size = new System.Drawing.Size(677, 22);
            this.textBoxGetMess.TabIndex = 3;
            this.textBoxGetMess.Text = ", доброго времени суток, могу ли я к вам обратиться? Я по деловому вопросу.";
            this.textBoxGetMess.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(232, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(405, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Перед запятой в тексте, будет автоматически указано имя! ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(235, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(480, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Введите id пользователя, друзей которого вы хотите порекрутировать.";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(238, 213);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(177, 22);
            this.textBoxId.TabIndex = 7;
            this.textBoxId.Text = "157007084";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(238, 171);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(484, 16);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://siteprokompy.ru/chto-takoe-id-polzovatelya-vkontakte-ili-odnoklassnikov/";
            this.linkLabel1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(924, 450);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxGetMess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listFriends);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Snow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listFriends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGetMess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

