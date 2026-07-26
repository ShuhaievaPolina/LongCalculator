namespace Kyrsova_2_sem
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Minus = new System.Windows.Forms.Button();
            this.InputNumber = new System.Windows.Forms.TextBox();
            this.Operation = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.InputNumber2 = new System.Windows.Forms.TextBox();
            this.Plus = new System.Windows.Forms.Button();
            this.Factorial = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Pov = new System.Windows.Forms.Button();
            this.Multiplication = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.TextLine = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.Equals = new System.Windows.Forms.Button();
            this.SaveToFile = new System.Windows.Forms.Button();
            this.LabelTime = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(this.Minus, 1, 6);
            tableLayoutPanel1.Controls.Add(this.InputNumber, 2, 1);
            tableLayoutPanel1.Controls.Add(this.Operation, 2, 2);
            tableLayoutPanel1.Controls.Add(this.Result, 2, 5);
            tableLayoutPanel1.Controls.Add(this.InputNumber2, 2, 3);
            tableLayoutPanel1.Controls.Add(this.Plus, 0, 6);
            tableLayoutPanel1.Controls.Add(this.Factorial, 0, 7);
            tableLayoutPanel1.Controls.Add(this.Label1, 2, 4);
            tableLayoutPanel1.Controls.Add(this.Pov, 1, 7);
            tableLayoutPanel1.Controls.Add(this.Multiplication, 2, 6);
            tableLayoutPanel1.Controls.Add(this.Division, 2, 7);
            tableLayoutPanel1.Controls.Add(this.TextLine, 0, 1);
            tableLayoutPanel1.Controls.Add(this.LabelName, 0, 0);
            tableLayoutPanel1.Controls.Add(this.ButtonDelete, 3, 6);
            tableLayoutPanel1.Controls.Add(this.Equals, 3, 7);
            tableLayoutPanel1.Controls.Add(this.SaveToFile, 4, 6);
            tableLayoutPanel1.Controls.Add(this.LabelTime, 2, 0);
            tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // Minus
            // 
            this.Minus.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Minus, "Minus");
            this.Minus.Name = "Minus";
            this.Minus.UseVisualStyleBackColor = false;
            this.Minus.Click += new System.EventHandler(this.buttonMinusClick);
            // 
            // InputNumber
            // 
            this.InputNumber.BackColor = System.Drawing.SystemColors.InactiveBorder;
            tableLayoutPanel1.SetColumnSpan(this.InputNumber, 3);
            resources.ApplyResources(this.InputNumber, "InputNumber");
            this.InputNumber.Name = "InputNumber";
            this.InputNumber.ReadOnly = true;
            // 
            // Operation
            // 
            this.Operation.BackColor = System.Drawing.SystemColors.InactiveBorder;
            resources.ApplyResources(this.Operation, "Operation");
            this.Operation.Name = "Operation";
            this.Operation.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.BackColor = System.Drawing.SystemColors.InactiveBorder;
            tableLayoutPanel1.SetColumnSpan(this.Result, 3);
            resources.ApplyResources(this.Result, "Result");
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // InputNumber2
            // 
            this.InputNumber2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            tableLayoutPanel1.SetColumnSpan(this.InputNumber2, 3);
            resources.ApplyResources(this.InputNumber2, "InputNumber2");
            this.InputNumber2.Name = "InputNumber2";
            this.InputNumber2.ReadOnly = true;
            // 
            // Plus
            // 
            this.Plus.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Plus, "Plus");
            this.Plus.Name = "Plus";
            this.Plus.UseVisualStyleBackColor = false;
            this.Plus.Click += new System.EventHandler(this.buttonPlusClick);
            // 
            // Factorial
            // 
            this.Factorial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Factorial, "Factorial");
            this.Factorial.Name = "Factorial";
            this.Factorial.UseVisualStyleBackColor = false;
            this.Factorial.Click += new System.EventHandler(this.buttonFactorialClick);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            tableLayoutPanel1.SetColumnSpan(this.Label1, 3);
            this.Label1.Name = "Label1";
            // 
            // Pov
            // 
            this.Pov.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Pov, "Pov");
            this.Pov.Name = "Pov";
            this.Pov.UseVisualStyleBackColor = false;
            this.Pov.Click += new System.EventHandler(this.buttonPovClick);
            // 
            // Multiplication
            // 
            this.Multiplication.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Multiplication, "Multiplication");
            this.Multiplication.Name = "Multiplication";
            this.Multiplication.UseVisualStyleBackColor = false;
            this.Multiplication.Click += new System.EventHandler(this.buttonMultiplicationClick);
            // 
            // Division
            // 
            this.Division.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Division, "Division");
            this.Division.Name = "Division";
            this.Division.UseVisualStyleBackColor = false;
            this.Division.Click += new System.EventHandler(this.buttonDivisionClick);
            // 
            // TextLine
            // 
            tableLayoutPanel1.SetColumnSpan(this.TextLine, 2);
            resources.ApplyResources(this.TextLine, "TextLine");
            this.TextLine.Name = "TextLine";
            tableLayoutPanel1.SetRowSpan(this.TextLine, 5);
            this.TextLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextLine_KeyPress);
            // 
            // LabelName
            // 
            resources.ApplyResources(this.LabelName, "LabelName");
            this.LabelName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            tableLayoutPanel1.SetColumnSpan(this.LabelName, 2);
            this.LabelName.Name = "LabelName";
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.ButtonDelete, "ButtonDelete");
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // Equals
            // 
            this.Equals.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.Equals, "Equals");
            this.Equals.Name = "Equals";
            this.Equals.UseVisualStyleBackColor = false;
            this.Equals.Click += new System.EventHandler(this.buttonEqualsClick);
            // 
            // SaveToFile
            // 
            this.SaveToFile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.SaveToFile, "SaveToFile");
            this.SaveToFile.Name = "SaveToFile";
            tableLayoutPanel1.SetRowSpan(this.SaveToFile, 2);
            this.SaveToFile.UseVisualStyleBackColor = false;
            this.SaveToFile.Click += new System.EventHandler(this.ButtonSaveToFile_Click);
            // 
            // LabelTime
            // 
            resources.ApplyResources(this.LabelTime, "LabelTime");
            tableLayoutPanel1.SetColumnSpan(this.LabelTime, 2);
            this.LabelTime.Name = "LabelTime";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button Multiplication;
        private System.Windows.Forms.Button Division;
        private System.Windows.Forms.Button Factorial;
        private System.Windows.Forms.Button Equals;
        private System.Windows.Forms.Button Pov;
        private System.Windows.Forms.TextBox TextLine;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button SaveToFile;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox InputNumber;
        private System.Windows.Forms.TextBox InputNumber2;
        private System.Windows.Forms.TextBox Operation;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label LabelTime;
    }
}

