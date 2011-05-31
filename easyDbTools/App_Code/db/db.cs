using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class db
{
    public static class ayarlar
    {
        public static string cs = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ToString();
    }
    
    // Insert Db Class
    public static int Insert(object Class, bool Identy)
    {
        int identity;
        string TabloAdi = "";
        try
        {
            using (SqlConnection conn = new SqlConnection(ayarlar.cs))
            {
                string strTemp = string.Empty;
                string strAlanAdi = string.Empty;
                string strVeri = string.Empty;
                SqlCommand sql = new SqlCommand();
                sql.Connection = conn;
                TabloAdi = Class.GetType().Name;
                foreach (var item in Class.GetType().GetProperties())
                {
                    if (item.GetValue(Class, item.GetIndexParameters()) != null)
                    {
                        strVeri = item.GetValue(Class, item.GetIndexParameters()).ToString();

                        if (item.PropertyType.FullName.Contains("System.DateTime"))
                        {
                            sql.Parameters.Add("@" + item.Name, SqlDbType.DateTime).Value = strVeri;
                        }
                        else if (item.PropertyType.Name == "Decimal")
                        {
                            sql.Parameters.Add("@" + item.Name, SqlDbType.Decimal).Value = strVeri;
                        }
                        else
                        {
                            sql.Parameters.Add("@" + item.Name, SqlDbType.NVarChar).Value = strVeri;
                        }
                        strTemp += "@" + item.Name + ",";
                        strAlanAdi += item.Name + ",";
                    }
                }
                strTemp = strTemp.Substring(0, strTemp.Length - 1);
                strAlanAdi = strAlanAdi.Substring(0, strAlanAdi.Length - 1);
                conn.Open();
                if (Identy)
                {
                    sql.CommandText = "Insert Into " + TabloAdi + " (" + strAlanAdi + ") values (" + strTemp + ") SELECT @@IDENTITY";
                    identity = Convert.ToInt32(sql.ExecuteScalar());
                }
                else
                {
                    sql.CommandText = "Insert Into " + TabloAdi + " (" + strAlanAdi + ") values (" + strTemp + ")";
                    sql.ExecuteNonQuery();
                    identity = 0;
                }
                sql.Dispose();
                conn.Close();
                return identity;
            }
        }
        catch (Exception h)
        {
            throw new Exception(h.Message);
        }
    }

    // Insert Db Class ve Html Form
    public static int Insert(object Class, HtmlGenericControl control, bool Identy)
    {
        int identity;
        string TabloAdi = "";
        try
        {
            using (SqlConnection conn = new SqlConnection(db.ayarlar.cs))
            {
                string strTemp = string.Empty;
                string strAlanAdi = string.Empty;
                string strVeri = string.Empty;
                SqlCommand sql = new SqlCommand();
                sql.Connection = conn;
                TabloAdi = Class.GetType().Name;
                foreach (var item in Class.GetType().GetProperties())
                {
                    strVeri = ClassToControl(control, item.Name);
                    if (strVeri != null)
                    {
                        if (item.PropertyType.FullName.Contains("System.DateTime"))
                        {
                            sql.Parameters.Add("@" + item.Name, SqlDbType.DateTime).Value = strVeri;
                        }
                        else if (item.PropertyType.Name == "Decimal")
                        {
                            sql.Parameters.Add("@" + item.Name, SqlDbType.Decimal).Value = strVeri;
                        }
                        else
                        {
                            sql.Parameters.Add("@" + item.Name, SqlDbType.NVarChar).Value = strVeri;
                        }
                        strTemp += "@" + item.Name + ",";
                        strAlanAdi += item.Name + ",";
                    }
                }
                strTemp = strTemp.Substring(0, strTemp.Length - 1);
                strAlanAdi = strAlanAdi.Substring(0, strAlanAdi.Length - 1);
                conn.Open();
                if (Identy)
                {
                    sql.CommandText = "Insert Into " + TabloAdi + " (" + strAlanAdi + ") values (" + strTemp + ") SELECT @@IDENTITY";
                    identity = Convert.ToInt32(sql.ExecuteScalar());
                }
                else
                {
                    sql.CommandText = "Insert Into " + TabloAdi + " (" + strAlanAdi + ") values (" + strTemp + ")";
                    sql.ExecuteNonQuery();
                    identity = 0;
                }
                sql.Dispose();
                conn.Close();
                return identity;
            }
        }
        catch (Exception h)
        {
            throw new Exception(h.Message);
        }
    }

    // Update Db Class
    public static void Update(object Class, string Where)
    {
        using (SqlConnection conn = new SqlConnection(ayarlar.cs))
        {
            string strTemp = string.Empty;
            string strVeri = string.Empty;
            string TabloAdi = string.Empty;
            SqlCommand sql = new SqlCommand();
            sql.Connection = conn;
            TabloAdi = Class.GetType().Name;
            foreach (var item in Class.GetType().GetProperties())
            {
                if (item.GetValue(Class, item.GetIndexParameters()) != null)
                {
                    strVeri = item.GetValue(Class, item.GetIndexParameters()).ToString();
                    if (item.PropertyType.FullName.Contains("System.DateTime"))
                    {
                        sql.Parameters.Add("@" + item.Name, SqlDbType.DateTime).Value = strVeri;
                    }
                    else if (item.PropertyType.Name == "Decimal")
                    {
                        sql.Parameters.Add("@" + item.Name, SqlDbType.Decimal).Value = strVeri;
                    }
                    else
                    {
                        sql.Parameters.Add("@" + item.Name, SqlDbType.NVarChar).Value = strVeri;
                    }
                    strTemp += item.Name + "=@" + item.Name + ",";
                }
            }
            strTemp = strTemp.Substring(0, strTemp.Length - 1);
            sql.CommandText = "Update " + TabloAdi + " Set " + strTemp + " " + Where + " ";
            conn.Open();
            sql.ExecuteNonQuery();
            sql.Dispose();
            conn.Close();
        }
    }
    
    // Update Db Class ve Html Form
    public static void Update(object Class, HtmlGenericControl control, string Where)
    {
        using (SqlConnection conn = new SqlConnection(ayarlar.cs))
        {
            string strTemp = string.Empty;
            string strVeri = string.Empty;
            string TabloAdi = string.Empty;
            SqlCommand sql = new SqlCommand();
            sql.Connection = conn;
            TabloAdi = Class.GetType().Name;
            foreach (var item in Class.GetType().GetProperties())
            {
                strVeri = ClassToControl(control, item.Name);
                if (!string.IsNullOrEmpty(strVeri))
                {
                    if (item.PropertyType.FullName.Contains("System.DateTime"))
                    {
                        sql.Parameters.Add("@" + item.Name, SqlDbType.DateTime).Value = strVeri;
                    }
                    else if (item.PropertyType.Name == "Decimal")
                    {
                        sql.Parameters.Add("@" + item.Name, SqlDbType.Decimal).Value = strVeri;
                    }
                    else
                    {
                        sql.Parameters.Add("@" + item.Name, SqlDbType.NVarChar).Value = strVeri;
                    }
                    strTemp += item.Name + "=@" + item.Name + ",";
                }
            }
            strTemp = strTemp.Substring(0, strTemp.Length - 1);
            sql.CommandText = "Update " + TabloAdi + " Set " + strTemp + " " + Where + " ";
            conn.Open();
            sql.ExecuteNonQuery();
            sql.Dispose();
            conn.Close();
        }
    }

    // Delete
    public static void Delete(string TabloAdi, string Where)
    {
        using (SqlConnection conn = new SqlConnection(ayarlar.cs))
        {
            SqlCommand sql = new SqlCommand("Delete from " + TabloAdi + " " + Where + " ", conn);
            conn.Open();
            sql.ExecuteNonQuery();
            sql.Dispose();
            conn.Close();
        }
    }

    // DataTable
    public static DataTable DTGetir(string SqlCommand)
    {
        SqlConnection conn = new SqlConnection(ayarlar.cs);
        SqlCommand cmd = new SqlCommand(SqlCommand, conn);
        cmd.CommandTimeout = 0;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "TABLE");
            return ds.Tables["TABLE"];
        }
        catch (SqlException hata)
        {
            throw new Exception(hata.Message);
        }
        finally
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn = null;
        }
    }
    
    // DataTable önbellek
    public static DataTable DTGetir(string SqlCommand, string CacheName)
    {
        Cache cache;
        object obj;
        cache = HttpContext.Current.Cache;
        obj = new object();

        if (cache[CacheName] == null)
        {
            lock (obj)
            {
                if (cache[CacheName] == null)
                {
                    SqlConnection conn = new SqlConnection(ayarlar.cs);
                    SqlDataAdapter da = new SqlDataAdapter(SqlCommand, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cache.Insert(CacheName, dt, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn = null;
                }
            }
        }
        return (DataTable)cache[CacheName];
    }

    // Execute Sql Command
    public static int Execute(string SqlCommand, bool Identy)
    {
        if (!string.IsNullOrEmpty(SqlCommand))
        {
            SqlConnection conn = new SqlConnection(ayarlar.cs);
            SqlCommand sql = new SqlCommand(SqlCommand, conn);
            conn.Open();
            try
            {
                if (Identy)
                {
                    sql.CommandText += " SELECT @@IDENTITY";
                    return Convert.ToInt32(sql.ExecuteScalar());
                }
                else
                {
                    sql.ExecuteNonQuery();
                    return 0;
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }

            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn = null;
            }
        }
        else
        {
            return 0;
        }
    }

    /* tool */
    public static string ClassToControl(HtmlGenericControl control, string strName)
    {
        string strValue = string.Empty;
        string strId = string.Empty;

        strName = strName.ToLower();

        foreach (Control item in control.Controls)
        {
            strId = null;
            strValue = null;
            if (item.ID != null)
            {
                strId = idDuzenle(item.ID);

                if (strId.ToLower() == strName)
                {
                    if (item is TextBox)
                    {
                        strValue = (item as TextBox).Text;
                    }
                    else if (item is DropDownList)
                    {
                        strValue = (item as DropDownList).SelectedValue;
                    }
                    else if (item is RadioButton)
                    {
                        strValue = (item as RadioButton).Checked.ToString();
                    }
                    else if (item is RadioButtonList)
                    {
                        strValue = (item as RadioButtonList).SelectedValue;
                    }
                    else if (item is CheckBox)
                    {
                        strValue = (item as CheckBox).Checked.ToString();
                    }
                    else if (item is CheckBoxList)
                    {
                        CheckBoxList cbl = item as CheckBoxList;
                        foreach (ListItem secilen in cbl.Items)
                        {
                            if (secilen.Selected)
                            {
                                //secilen.Value;
                            }
                        }
                    }
                    return strValue;
                }

            }
        }

        return null;
    }
    public static string idDuzenle(string strGelen)
    {
        return strGelen.Substring(3, strGelen.Length - 3);
    }
}