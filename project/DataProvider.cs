﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public class DataProvider
    {

        SqlConnection connection = new SqlConnection();
        public DataProvider()
        {
            try
            {
                connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\OS\source\repos\QuanLy_CF\project\QL_QUANCAFE.mdf;Integrated Security=True";
                connection.Open();
            }
            catch { }
        }
        public DataTable loadAccount()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_account";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public DataTable loadTableF()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_tableF";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public DataTable loadBillInfo(string nameT)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_billinfo";
            command.Parameters.AddWithValue("@NAMETABLE", SqlDbType.NVarChar).Value = nameT;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        
        public DataTable loadCategory()
        {
            DataTable data = new DataTable();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_load_category";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            return data;
        }
        public DataTable loadAllFood()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_AllFood";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public DataTable loadFood(string nameC)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_load_food";
                command.Parameters.AddWithValue("@NAMECATEGORY", SqlDbType.NVarChar).Value = nameC;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            return data;
        }

        public DataTable loadTableFoodBill(string nameT)
        {
            DataTable data = new DataTable();
             SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_table_food_bill";
                command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = nameT;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            return data;
        }


        public void Datban(string stt, string nameT)
        {
            SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_datban";
                command.Parameters.AddWithValue("@STT", SqlDbType.NVarChar).Value = stt;
                command.Parameters.AddWithValue("@NAMETable", SqlDbType.NVarChar).Value = nameT;
                command.ExecuteNonQuery();
                connection.Close();
        }
        
        public void AddAccount(string USERNAME, string DISPLAYNAME, string PASSWORD, string TYPEACCOUNT)
        {
                SqlCommand command = new SqlCommand("sp_Add_Account",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@USERNAME", SqlDbType.NVarChar).Value = USERNAME;
                command.Parameters.AddWithValue("@DISPLAYNAME", SqlDbType.NVarChar).Value = DISPLAYNAME;
                command.Parameters.AddWithValue("@PASSWORD", SqlDbType.NVarChar).Value = PASSWORD;
                command.Parameters.AddWithValue("@TYPEACCOUNT", SqlDbType.NVarChar).Value = TYPEACCOUNT;
                command.ExecuteNonQuery();
                connection.Close();
        }

        
        public void DelAccount(string USERNAME)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Del_Account";
            command.Parameters.AddWithValue("@USERNAME", SqlDbType.NVarChar).Value = USERNAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateAccount(string USERNAME, string DISPLAYNAME, string PASSWORD, string TYPEACCOUNT,string Where)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Update_Account";
            command.Parameters.AddWithValue("@USERNAME", SqlDbType.NVarChar).Value = USERNAME;
            command.Parameters.AddWithValue("@DISPLAYNAME", SqlDbType.NVarChar).Value = DISPLAYNAME;
            command.Parameters.AddWithValue("@PASSWORD", SqlDbType.NVarChar).Value = PASSWORD;
            command.Parameters.AddWithValue("@TYPEACCOUNT", SqlDbType.NVarChar).Value = TYPEACCOUNT;
            command.Parameters.AddWithValue("@Where_USERNAME", SqlDbType.NVarChar).Value = Where;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddFood(string NAMECATEGORY, string NAME, float PRICE)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_add_food";
            command.Parameters.AddWithValue("@NAMECATEGORY", SqlDbType.NVarChar).Value = NAMECATEGORY;
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@PRICE", SqlDbType.Float).Value = PRICE;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DelFood(string NAMECATEGORY)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_del_food";
            command.Parameters.AddWithValue("@NAMECATEGORY", SqlDbType.NVarChar).Value = NAMECATEGORY;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateFood(string NAMECATEGORY, string NAME, float PRICE,string where)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_update_food";
            command.Parameters.AddWithValue("@NAMECATEGORY", SqlDbType.NVarChar).Value = NAMECATEGORY;
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@PRICE", SqlDbType.Float).Value = PRICE;
            command.Parameters.AddWithValue("@Where_name", SqlDbType.NVarChar).Value = where;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddTable(string NAME)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_add_table";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DelTable(string NAME)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_del_table";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateTable(string NAME,string where)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_update_table";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@Where_NAME", SqlDbType.NVarChar).Value = where;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void giammon(string NAMET, string NAMEF, int count, float total)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_sua_sl_mon";
            command.Parameters.AddWithValue("@NAMET", SqlDbType.NVarChar).Value = NAMET;
            command.Parameters.AddWithValue("@NAMEF", SqlDbType.NVarChar).Value = NAMEF;
            command.Parameters.AddWithValue("@count", SqlDbType.Int).Value = count;
            command.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand();
            command2.Connection = connection;
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "sp_sua_total";
            command2.Parameters.AddWithValue("@NAMET", SqlDbType.NVarChar).Value = NAMET;
            command2.Parameters.AddWithValue("@total", SqlDbType.Float).Value = total;
            command2.ExecuteNonQuery();
            connection.Close();
        }


        public void move_food(string NAMETABLE,string NAMEFOOD,int COUNTS)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_move_food";
            command.Parameters.AddWithValue("@NAMETABLE", SqlDbType.NVarChar).Value = NAMETABLE;
            command.Parameters.AddWithValue("@NAMEFOOD", SqlDbType.NVarChar).Value = NAMEFOOD;
            command.Parameters.AddWithValue("@COUNTS", SqlDbType.Int).Value = COUNTS;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void move_table(float TOTAL, string NAMET,string NAMEF)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_move_table";
            command.Parameters.AddWithValue("@TOTAL", SqlDbType.Float).Value = TOTAL;
            command.Parameters.AddWithValue("@NAMET", SqlDbType.NVarChar).Value = NAMET;
            command.Parameters.AddWithValue("@NAMEF", SqlDbType.NVarChar).Value = NAMEF;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable check_table(string NAMET)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_check_table";
            command.Parameters.AddWithValue("@NAMET", SqlDbType.NVarChar).Value = NAMET;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }


        public void AddCate(string NAMEC)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_add_category";
            command.Parameters.AddWithValue("@NAMEC", SqlDbType.NVarChar).Value = NAMEC;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DelCate(string NAMEC)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Del_category";
            command.Parameters.AddWithValue("@NAMEC", SqlDbType.NVarChar).Value = NAMEC;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateCate(string NAMEC,string Where)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_Update_category";
            command.Parameters.AddWithValue("@NAMEC", SqlDbType.NVarChar).Value = NAMEC;
            command.Parameters.AddWithValue("@Where_cate", SqlDbType.NVarChar).Value = Where;
            command.ExecuteNonQuery();
            connection.Close();
        }


        public DataTable loadFoodTable(string NAMET)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_food_table";
            command.Parameters.AddWithValue("@NAMET", SqlDbType.NVarChar).Value = NAMET;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public void GopTable(string NAMETABLEA, string NAMETABLEB, float addTotal)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_gop_Table";
            command.Parameters.AddWithValue("@NAMETABLEA", SqlDbType.NVarChar).Value = NAMETABLEA;
            command.Parameters.AddWithValue("@NAMETABLEB", SqlDbType.NVarChar).Value = NAMETABLEB;
            command.Parameters.AddWithValue("@addTotal", SqlDbType.NVarChar).Value = addTotal;
            command.ExecuteNonQuery();
            connection.Close();
        }



        public DataTable loadTableWhere(string NAME)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_table_where";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public DataTable loadBillWhere(string NAME)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_load_bill_where";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public void ClearTable(string NAME)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_clear_table";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ClearBill(string NAME)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_clear_bill";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ResetTable(string NAME)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_reset_table";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ThemMon(string NAME,string NAMEFood, int count)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_them_mon";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@NAMEFood", SqlDbType.NVarChar).Value = NAMEFood;
            command.Parameters.AddWithValue("@count", SqlDbType.Int).Value = count;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void TangSLMon(string NAME, string NAMEFood, int count)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_tang_slmon";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@NAMEFood", SqlDbType.NVarChar).Value = NAMEFood;
            command.Parameters.AddWithValue("@count", SqlDbType.Int).Value = count;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable checkFoodTable(string NAME, string NAMEFood)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_check_food_table";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@NAMEFood", SqlDbType.NVarChar).Value = NAMEFood;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public DataTable getPrice(string NAMEFood)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_get_price";
            command.Parameters.AddWithValue("@NAMEFood", SqlDbType.NVarChar).Value = NAMEFood;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }
        public void setTotal(string NAME, float total)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_set_total";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = NAME;
            command.Parameters.AddWithValue("@total", SqlDbType.Float).Value = total;
            command.ExecuteNonQuery();
            connection.Close();
        }



        public void resetAccount(string DISPLAYNAME, string PASS, string USER)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_reset_account";
            command.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = USER;
            command.Parameters.AddWithValue("@PASS", SqlDbType.NVarChar).Value = PASS;
            command.Parameters.AddWithValue("@DISPLAYNAME", SqlDbType.NVarChar).Value = DISPLAYNAME;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
      
}
        