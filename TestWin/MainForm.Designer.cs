
namespace ShellCommand
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	this.tb_cmd = new System.Windows.Forms.TextBox();
        	this.btn_execute = new System.Windows.Forms.Button();
        	this.tb_result = new System.Windows.Forms.TextBox();
        	this.SuspendLayout();
        	// 
        	// tb_cmd
        	// 
        	this.tb_cmd.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tb_cmd.Location = new System.Drawing.Point(12, 12);
        	this.tb_cmd.Name = "tb_cmd";
        	this.tb_cmd.Size = new System.Drawing.Size(487, 20);
        	this.tb_cmd.TabIndex = 0;
        	this.tb_cmd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_cmdKeyPress);
        	// 
        	// btn_execute
        	// 
        	this.btn_execute.Location = new System.Drawing.Point(505, 10);
        	this.btn_execute.Name = "btn_execute";
        	this.btn_execute.Size = new System.Drawing.Size(75, 23);
        	this.btn_execute.TabIndex = 1;
        	this.btn_execute.Text = "Execute";
        	this.btn_execute.UseVisualStyleBackColor = true;
        	this.btn_execute.Click += new System.EventHandler(this.Btn_executeClick);
        	// 
        	// tb_result
        	// 
        	this.tb_result.BackColor = System.Drawing.Color.Black;
        	this.tb_result.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tb_result.ForeColor = System.Drawing.Color.DarkGray;
        	this.tb_result.Location = new System.Drawing.Point(12, 41);
        	this.tb_result.Multiline = true;
        	this.tb_result.Name = "tb_result";
        	this.tb_result.ReadOnly = true;
        	this.tb_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.tb_result.Size = new System.Drawing.Size(568, 313);
        	this.tb_result.TabIndex = 2;
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(592, 366);
        	this.Controls.Add(this.tb_result);
        	this.Controls.Add(this.btn_execute);
        	this.Controls.Add(this.tb_cmd);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.Name = "MainForm";
        	this.Text = "TestWin";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.TextBox tb_cmd;
        private System.Windows.Forms.Button btn_execute;
    }
}
