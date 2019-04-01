namespace Trasen.Print.Implement.Grid__
{
    partial class FrmReportDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( FrmReportDesigner ) );
            this.axGRDesigner1 = new AxgrdesLib.AxGRDesigner();
            ( (System.ComponentModel.ISupportInitialize)( this.axGRDesigner1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // axGRDesigner1
            // 
            this.axGRDesigner1.Enabled = true;
            this.axGRDesigner1.Location = new System.Drawing.Point( 26 , 12 );
            this.axGRDesigner1.Name = "axGRDesigner1";
            this.axGRDesigner1.OcxState = ( (System.Windows.Forms.AxHost.State)( resources.GetObject( "axGRDesigner1.OcxState" ) ) );
            this.axGRDesigner1.Size = new System.Drawing.Size( 748 , 458 );
            this.axGRDesigner1.TabIndex = 0;
            // 
            // FrmReportDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F , 12F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 800 , 500 );
            this.Controls.Add( this.axGRDesigner1 );
            this.Name = "FrmReportDesigner";
            this.Text = "FrmReportDesigner";
            ( (System.ComponentModel.ISupportInitialize)( this.axGRDesigner1 ) ).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private AxgrdesLib.AxGRDesigner axGRDesigner1;
    }
}