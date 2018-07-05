namespace Database_connecting
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
            this.components = new System.ComponentModel.Container();
            this.отчётBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sewing_factoryDataSet = new Database_connecting.Sewing_factoryDataSet();
            this.отчётTableAdapter = new Database_connecting.Sewing_factoryDataSetTableAdapters.ОтчётTableAdapter();
            this.lots = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finalpriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateendregistrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateendfirstpartsreviewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datebeginauctionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateendauctionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateendsecondpartsreviewDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lotsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRACTDataSet = new Database_connecting.PRACTDataSet();
            this.lotsTableAdapter = new Database_connecting.PRACTDataSetTableAdapters.lotsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.Enter = new System.Windows.Forms.Button();
            this.testBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.отчётBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sewing_factoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRACTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // отчётBindingSource
            // 
            this.отчётBindingSource.DataMember = "Отчёт";
            this.отчётBindingSource.DataSource = this.sewing_factoryDataSet;
            // 
            // sewing_factoryDataSet
            // 
            this.sewing_factoryDataSet.DataSetName = "Sewing_factoryDataSet";
            this.sewing_factoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // отчётTableAdapter
            // 
            this.отчётTableAdapter.ClearBeforeFill = true;
            // 
            // lots
            // 
            this.lots.AutoGenerateColumns = false;
            this.lots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.subjectDataGridViewTextBoxColumn,
            this.startpriceDataGridViewTextBoxColumn,
            this.finalpriceDataGridViewTextBoxColumn,
            this.dateendregistrationDataGridViewTextBoxColumn,
            this.dateendfirstpartsreviewDataGridViewTextBoxColumn,
            this.datebeginauctionDataGridViewTextBoxColumn,
            this.dateendauctionDataGridViewTextBoxColumn,
            this.dateendsecondpartsreviewDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.actualDataGridViewCheckBoxColumn});
            this.lots.DataSource = this.lotsBindingSource;
            this.lots.Location = new System.Drawing.Point(12, 12);
            this.lots.Name = "lots";
            this.lots.Size = new System.Drawing.Size(934, 150);
            this.lots.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            this.subjectDataGridViewTextBoxColumn.DataPropertyName = "subject";
            this.subjectDataGridViewTextBoxColumn.HeaderText = "subject";
            this.subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            // 
            // startpriceDataGridViewTextBoxColumn
            // 
            this.startpriceDataGridViewTextBoxColumn.DataPropertyName = "start_price";
            this.startpriceDataGridViewTextBoxColumn.HeaderText = "start_price";
            this.startpriceDataGridViewTextBoxColumn.Name = "startpriceDataGridViewTextBoxColumn";
            // 
            // finalpriceDataGridViewTextBoxColumn
            // 
            this.finalpriceDataGridViewTextBoxColumn.DataPropertyName = "final_price";
            this.finalpriceDataGridViewTextBoxColumn.HeaderText = "final_price";
            this.finalpriceDataGridViewTextBoxColumn.Name = "finalpriceDataGridViewTextBoxColumn";
            // 
            // dateendregistrationDataGridViewTextBoxColumn
            // 
            this.dateendregistrationDataGridViewTextBoxColumn.DataPropertyName = "date_end_registration";
            this.dateendregistrationDataGridViewTextBoxColumn.HeaderText = "date_end_registration";
            this.dateendregistrationDataGridViewTextBoxColumn.Name = "dateendregistrationDataGridViewTextBoxColumn";
            // 
            // dateendfirstpartsreviewDataGridViewTextBoxColumn
            // 
            this.dateendfirstpartsreviewDataGridViewTextBoxColumn.DataPropertyName = "date_end_first_parts_review";
            this.dateendfirstpartsreviewDataGridViewTextBoxColumn.HeaderText = "date_end_first_parts_review";
            this.dateendfirstpartsreviewDataGridViewTextBoxColumn.Name = "dateendfirstpartsreviewDataGridViewTextBoxColumn";
            // 
            // datebeginauctionDataGridViewTextBoxColumn
            // 
            this.datebeginauctionDataGridViewTextBoxColumn.DataPropertyName = "date_begin_auction";
            this.datebeginauctionDataGridViewTextBoxColumn.HeaderText = "date_begin_auction";
            this.datebeginauctionDataGridViewTextBoxColumn.Name = "datebeginauctionDataGridViewTextBoxColumn";
            // 
            // dateendauctionDataGridViewTextBoxColumn
            // 
            this.dateendauctionDataGridViewTextBoxColumn.DataPropertyName = "date_end_auction";
            this.dateendauctionDataGridViewTextBoxColumn.HeaderText = "date_end_auction";
            this.dateendauctionDataGridViewTextBoxColumn.Name = "dateendauctionDataGridViewTextBoxColumn";
            // 
            // dateendsecondpartsreviewDataGridViewTextBoxColumn
            // 
            this.dateendsecondpartsreviewDataGridViewTextBoxColumn.DataPropertyName = "date_end_second_parts_review";
            this.dateendsecondpartsreviewDataGridViewTextBoxColumn.HeaderText = "date_end_second_parts_review";
            this.dateendsecondpartsreviewDataGridViewTextBoxColumn.Name = "dateendsecondpartsreviewDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            // 
            // actualDataGridViewCheckBoxColumn
            // 
            this.actualDataGridViewCheckBoxColumn.DataPropertyName = "actual";
            this.actualDataGridViewCheckBoxColumn.HeaderText = "actual";
            this.actualDataGridViewCheckBoxColumn.Name = "actualDataGridViewCheckBoxColumn";
            // 
            // lotsBindingSource
            // 
            this.lotsBindingSource.DataMember = "lots";
            this.lotsBindingSource.DataSource = this.pRACTDataSet;
            // 
            // pRACTDataSet
            // 
            this.pRACTDataSet.DataSetName = "PRACTDataSet";
            this.pRACTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lotsTableAdapter
            // 
            this.lotsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Вход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // login
            // 
            this.login.ForeColor = System.Drawing.Color.Gray;
            this.login.Location = new System.Drawing.Point(426, 251);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(100, 20);
            this.login.TabIndex = 3;
            this.login.Text = "login";
            this.login.MouseClick += new System.Windows.Forms.MouseEventHandler(this.login_MouseClick);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(426, 296);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 4;
            this.password.Text = "password";
            this.password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.password_MouseClick);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(426, 347);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(100, 23);
            this.Enter.TabIndex = 5;
            this.Enter.Text = "Войти";
            this.Enter.UseVisualStyleBackColor = true;
            // 
            // testBox1
            // 
            this.testBox1.Location = new System.Drawing.Point(772, 296);
            this.testBox1.Name = "testBox1";
            this.testBox1.Size = new System.Drawing.Size(100, 20);
            this.testBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.testBox1);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lots);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.отчётBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sewing_factoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRACTDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sewing_factoryDataSet sewing_factoryDataSet;
        private System.Windows.Forms.BindingSource отчётBindingSource;
        private Sewing_factoryDataSetTableAdapters.ОтчётTableAdapter отчётTableAdapter;
        private System.Windows.Forms.DataGridView lots;

        

        private PRACTDataSet pRACTDataSet;
        private System.Windows.Forms.BindingSource lotsBindingSource;
        private PRACTDataSetTableAdapters.lotsTableAdapter lotsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finalpriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateendregistrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateendfirstpartsreviewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datebeginauctionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateendauctionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateendsecondpartsreviewDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn actualDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.TextBox testBox1;
    }
}

