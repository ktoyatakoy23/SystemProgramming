using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace SQLiteSample
{
    public partial class Form1 : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConnection;
        private SQLiteCommand m_sqlCmd;

        public Form1()
        {
            InitializeComponent();
            create_btn.Click += create_btn_Click;
            del_btn.Click += del_btn_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_dbConnection = new SQLiteConnection();
           

            dbFileName = @"C:\Users\User\Desktop\колледж программирования\бд\source\\testDB.db";

            if (!File.Exists(dbFileName))
                MessageBox.Show("Please, create DB and blank table (Push \"Create\" button)");

            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3; New=False; Compress=True;");
                m_dbConnection.Open();
                MessageBox.Show("база данных открыта");
               
                
                
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            string UserInputFor_TEST_TEXT = TEST_TEXT.Text;
            string UserInputFor_TEST_TEXT2 = TEST_TEXT2.Text;
            string UserInputFor_TEST_TEXT3 = TEST_TEXT3.Text;

            string sql_add = "INSERT INTO TestDb (TEST_TEXT, TEST_TEXT2, TEST_TEXT3) VALUES (@значение,  @значение2,  @значение3 );";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_add, m_dbConnection);
           
            m_sqlCmd.Parameters.AddWithValue("@значение", UserInputFor_TEST_TEXT);
            m_sqlCmd.Parameters.AddWithValue("@значение2", UserInputFor_TEST_TEXT2);
            m_sqlCmd.Parameters.AddWithValue("@значение3", UserInputFor_TEST_TEXT3);
            
            m_sqlCmd.ExecuteNonQuery();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            string sql_delete = "DELETE FROM TestDb WHERE id = (SELECT id  FROM TestDb ORDER BY id DESC LIMIT 1);";
            SQLiteCommand m_sqlCmd = new SQLiteCommand(sql_delete, m_dbConnection);
            m_sqlCmd.ExecuteNonQuery();
        }
        //private void btCreate_Click(object sender, EventArgs e)
        //{
        //    if (!File.Exists(dbFileName))
        //        SQLiteConnection.CreateFile(dbFileName);

        //    try
        //    {
        //        m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
        //        m_dbConn.Open();
        //        m_sqlCmd.Connection = m_dbConn;

        //        m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Catalog (id INTEGER PRIMARY KEY AUTOINCREMENT, author TEXT, book TEXT)";                
        //        m_sqlCmd.ExecuteNonQuery();

        //        lbStatusText.Text = "Connected";
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        lbStatusText.Text = "Disconnected";
        //        MessageBox.Show("Error: " + ex.Message);
        //    }           
        //}



        //private void btReadAll_Click(object sender, EventArgs e)
        //{
        //    DataTable dTable = new DataTable();
        //    String sqlQuery;

        //    if (m_dbConn.State != ConnectionState.Open)
        //    {
        //        MessageBox.Show("Open connection with database");
        //        return;
        //    }

        //    try
        //    {
        //        sqlQuery = "SELECT * FROM Catalog";
        //        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
        //        adapter.Fill(dTable);

        //        if (dTable.Rows.Count > 0)
        //        {
        //            dgvViewer.Rows.Clear();

        //            for (int i = 0; i < dTable.Rows.Count; i++)
        //                dgvViewer.Rows.Add(dTable.Rows[i].ItemArray);
        //        }
        //        else
        //            MessageBox.Show("Database is empty");
        //    }
        //    catch (SQLiteException ex)
        //    {               
        //        MessageBox.Show("Error: " + ex.Message);
        //    }           
        //}       




    }
}
