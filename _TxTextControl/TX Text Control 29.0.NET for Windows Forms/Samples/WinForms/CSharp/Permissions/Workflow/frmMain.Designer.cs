namespace Workflow
{
    partial class frmMain
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
            this.gbUserAdministration = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDesignDocument = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDesignDocument = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.gbOpenDocument = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenDocument = new System.Windows.Forms.Button();
            this.gbUserAdministration.SuspendLayout();
            this.gbDesignDocument.SuspendLayout();
            this.gbOpenDocument.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUserAdministration
            // 
            this.gbUserAdministration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserAdministration.Controls.Add(this.label1);
            this.gbUserAdministration.Controls.Add(this.btnManageUsers);
            this.gbUserAdministration.Location = new System.Drawing.Point(110, 12);
            this.gbUserAdministration.Name = "gbUserAdministration";
            this.gbUserAdministration.Size = new System.Drawing.Size(365, 113);
            this.gbUserAdministration.TabIndex = 0;
            this.gbUserAdministration.TabStop = false;
            this.gbUserAdministration.Text = "User Administration";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "In this workflow step, users can be created. The administrator or designer of a d" +
    "ocument can choose from these users to create editable regions in a protected do" +
    "cument.";
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.AutoSize = true;
            this.btnManageUsers.Location = new System.Drawing.Point(9, 79);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(93, 23);
            this.btnManageUsers.TabIndex = 0;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Step 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Step 2";
            // 
            // gbDesignDocument
            // 
            this.gbDesignDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDesignDocument.Controls.Add(this.label4);
            this.gbDesignDocument.Controls.Add(this.btnDesignDocument);
            this.gbDesignDocument.Enabled = false;
            this.gbDesignDocument.Location = new System.Drawing.Point(110, 147);
            this.gbDesignDocument.Name = "gbDesignDocument";
            this.gbDesignDocument.Size = new System.Drawing.Size(365, 113);
            this.gbDesignDocument.TabIndex = 2;
            this.gbDesignDocument.TabStop = false;
            this.gbDesignDocument.Text = "Design Document as Administrator";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(353, 49);
            this.label4.TabIndex = 1;
            this.label4.Text = "In step 2, an instance of TX Text Control is created with full permissions to des" +
    "ign a document with editiable regions.";
            // 
            // btnDesignDocument
            // 
            this.btnDesignDocument.AutoSize = true;
            this.btnDesignDocument.Location = new System.Drawing.Point(9, 79);
            this.btnDesignDocument.Name = "btnDesignDocument";
            this.btnDesignDocument.Size = new System.Drawing.Size(102, 23);
            this.btnDesignDocument.TabIndex = 0;
            this.btnDesignDocument.Text = "Design Document";
            this.btnDesignDocument.UseVisualStyleBackColor = true;
            this.btnDesignDocument.Click += new System.EventHandler(this.btnDesignDocument_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "Step 3";
            // 
            // gbOpenDocument
            // 
            this.gbOpenDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOpenDocument.Controls.Add(this.label6);
            this.gbOpenDocument.Controls.Add(this.btnOpenDocument);
            this.gbOpenDocument.Enabled = false;
            this.gbOpenDocument.Location = new System.Drawing.Point(110, 285);
            this.gbOpenDocument.Name = "gbOpenDocument";
            this.gbOpenDocument.Size = new System.Drawing.Size(365, 113);
            this.gbOpenDocument.TabIndex = 4;
            this.gbOpenDocument.TabStop = false;
            this.gbOpenDocument.Text = "Open Document as a Specific User";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(353, 49);
            this.label6.TabIndex = 1;
            this.label6.Text = "In step 3, an instance of TX Text Control is created with restricted permissions." +
    "";
            // 
            // btnOpenDocument
            // 
            this.btnOpenDocument.AutoSize = true;
            this.btnOpenDocument.Location = new System.Drawing.Point(9, 79);
            this.btnOpenDocument.Name = "btnOpenDocument";
            this.btnOpenDocument.Size = new System.Drawing.Size(102, 23);
            this.btnOpenDocument.TabIndex = 0;
            this.btnOpenDocument.Text = "Open Document";
            this.btnOpenDocument.UseVisualStyleBackColor = true;
            this.btnOpenDocument.Click += new System.EventHandler(this.btnOpenDocument_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 411);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbOpenDocument);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbDesignDocument);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbUserAdministration);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(3000, 450);
            this.MinimumSize = new System.Drawing.Size(503, 450);
            this.Name = "frmMain";
            this.Text = "Permissions Workflow Sample";
            this.gbUserAdministration.ResumeLayout(false);
            this.gbUserAdministration.PerformLayout();
            this.gbDesignDocument.ResumeLayout(false);
            this.gbDesignDocument.PerformLayout();
            this.gbOpenDocument.ResumeLayout(false);
            this.gbOpenDocument.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUserAdministration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDesignDocument;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDesignDocument;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbOpenDocument;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenDocument;
    }
}

