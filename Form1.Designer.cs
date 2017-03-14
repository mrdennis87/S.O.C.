namespace NissanUDS
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
            this.components = new System.ComponentModel.Container();
            this.Lst_PIDS_Supported = new System.Windows.Forms.ListBox();
            this.Lbl_Status = new System.Windows.Forms.Label();
            this.SP = new System.IO.Ports.SerialPort(this.components);
            this.Btn_Connect_To_Vehicle = new System.Windows.Forms.Button();
            this.Txt_Module_Id = new System.Windows.Forms.TextBox();
            this.Txt_Data = new System.Windows.Forms.TextBox();
            this.Btn_Send_Program_Number = new System.Windows.Forms.Button();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_SetHeader = new System.Windows.Forms.Button();
            this.Btn_GetOutputControls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lst_PIDS_Supported
            // 
            this.Lst_PIDS_Supported.BackColor = System.Drawing.Color.Silver;
            this.Lst_PIDS_Supported.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lst_PIDS_Supported.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Lst_PIDS_Supported.FormattingEnabled = true;
            this.Lst_PIDS_Supported.ItemHeight = 18;
            this.Lst_PIDS_Supported.Location = new System.Drawing.Point(193, 26);
            this.Lst_PIDS_Supported.Margin = new System.Windows.Forms.Padding(2);
            this.Lst_PIDS_Supported.Name = "Lst_PIDS_Supported";
            this.Lst_PIDS_Supported.Size = new System.Drawing.Size(207, 274);
            this.Lst_PIDS_Supported.TabIndex = 2;
            // 
            // Lbl_Status
            // 
            this.Lbl_Status.AutoSize = true;
            this.Lbl_Status.Font = new System.Drawing.Font("Modern No. 20", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Lbl_Status.Location = new System.Drawing.Point(675, 313);
            this.Lbl_Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Status.Name = "Lbl_Status";
            this.Lbl_Status.Size = new System.Drawing.Size(76, 17);
            this.Lbl_Status.TabIndex = 3;
            this.Lbl_Status.Text = "...Status...";
            // 
            // SP
            // 
            this.SP.BaudRate = 38400;
            this.SP.PortName = "COM7";
            // 
            // Btn_Connect_To_Vehicle
            // 
            this.Btn_Connect_To_Vehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Connect_To_Vehicle.Location = new System.Drawing.Point(9, 26);
            this.Btn_Connect_To_Vehicle.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Connect_To_Vehicle.Name = "Btn_Connect_To_Vehicle";
            this.Btn_Connect_To_Vehicle.Size = new System.Drawing.Size(180, 32);
            this.Btn_Connect_To_Vehicle.TabIndex = 4;
            this.Btn_Connect_To_Vehicle.Text = "1) Connect To Vehicle";
            this.Btn_Connect_To_Vehicle.UseVisualStyleBackColor = true;
            this.Btn_Connect_To_Vehicle.Click += new System.EventHandler(this.Btn_Connect_To_Vehicle_Click);
            // 
            // Txt_Module_Id
            // 
            this.Txt_Module_Id.BackColor = System.Drawing.Color.Silver;
            this.Txt_Module_Id.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Module_Id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Txt_Module_Id.Location = new System.Drawing.Point(11, 98);
            this.Txt_Module_Id.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Module_Id.Multiline = true;
            this.Txt_Module_Id.Name = "Txt_Module_Id";
            this.Txt_Module_Id.Size = new System.Drawing.Size(177, 25);
            this.Txt_Module_Id.TabIndex = 6;
            this.Txt_Module_Id.Text = "7E0";
            this.Txt_Module_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Data
            // 
            this.Txt_Data.BackColor = System.Drawing.Color.Silver;
            this.Txt_Data.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Txt_Data.Location = new System.Drawing.Point(404, 26);
            this.Txt_Data.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Data.Multiline = true;
            this.Txt_Data.Name = "Txt_Data";
            this.Txt_Data.Size = new System.Drawing.Size(611, 272);
            this.Txt_Data.TabIndex = 9;
            this.Txt_Data.Text = "Data";
            this.Txt_Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btn_Send_Program_Number
            // 
            this.Btn_Send_Program_Number.Location = new System.Drawing.Point(938, 308);
            this.Btn_Send_Program_Number.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Send_Program_Number.Name = "Btn_Send_Program_Number";
            this.Btn_Send_Program_Number.Size = new System.Drawing.Size(73, 26);
            this.Btn_Send_Program_Number.TabIndex = 13;
            this.Btn_Send_Program_Number.Text = "Example";
            this.Btn_Send_Program_Number.UseVisualStyleBackColor = true;
            this.Btn_Send_Program_Number.Click += new System.EventHandler(this.Btn_Send_Program_Number_Click);
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Location = new System.Drawing.Point(193, 304);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(75, 26);
            this.Btn_Clear.TabIndex = 14;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(325, 305);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 26);
            this.Btn_Save.TabIndex = 15;
            this.Btn_Save.Text = "...Save...";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_SetHeader
            // 
            this.Btn_SetHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SetHeader.Location = new System.Drawing.Point(8, 62);
            this.Btn_SetHeader.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_SetHeader.Name = "Btn_SetHeader";
            this.Btn_SetHeader.Size = new System.Drawing.Size(180, 32);
            this.Btn_SetHeader.TabIndex = 16;
            this.Btn_SetHeader.Text = "2) Set Header              ";
            this.Btn_SetHeader.UseVisualStyleBackColor = true;
            this.Btn_SetHeader.Click += new System.EventHandler(this.Btn_SetHeader_Click);
            // 
            // Btn_GetOutputControls
            // 
            this.Btn_GetOutputControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_GetOutputControls.Location = new System.Drawing.Point(9, 249);
            this.Btn_GetOutputControls.Name = "Btn_GetOutputControls";
            this.Btn_GetOutputControls.Size = new System.Drawing.Size(179, 49);
            this.Btn_GetOutputControls.TabIndex = 17;
            this.Btn_GetOutputControls.Text = "Get Output Controls";
            this.Btn_GetOutputControls.UseVisualStyleBackColor = true;
            this.Btn_GetOutputControls.Click += new System.EventHandler(this.Btn_GetOutputControls_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1022, 337);
            this.Controls.Add(this.Btn_GetOutputControls);
            this.Controls.Add(this.Btn_SetHeader);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_Send_Program_Number);
            this.Controls.Add(this.Txt_Data);
            this.Controls.Add(this.Txt_Module_Id);
            this.Controls.Add(this.Btn_Connect_To_Vehicle);
            this.Controls.Add(this.Lbl_Status);
            this.Controls.Add(this.Lst_PIDS_Supported);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Toyota/Lexus OUTPUT Control Listing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Lst_PIDS_Supported;
        private System.Windows.Forms.Label Lbl_Status;
        private System.IO.Ports.SerialPort SP;
        private System.Windows.Forms.Button Btn_Connect_To_Vehicle;
        private System.Windows.Forms.TextBox Txt_Module_Id;
        private System.Windows.Forms.TextBox Txt_Data;
        private System.Windows.Forms.Button Btn_Send_Program_Number;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_SetHeader;
        private System.Windows.Forms.Button Btn_GetOutputControls;
    }
}

