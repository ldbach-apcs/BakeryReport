using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BakeryReport
{
    public class DatabaseHelper
    {
        private const String DB_NAME = "BakeryReport";
        private String CnnVal()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[DB_NAME].ConnectionString;
            } catch (NullReferenceException exception)
            {
                // Dummy catch :) 
                return exception.ToString();
            }
        }

        public void DbAddIngridient(String name, int price, float quantity) {
            // This make sure each sqlConection is terminated after usage
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                cnn.Execute(
                    "dbo.sp_IngridientAdd @nlName, @nlGia, @nlSoLuong", 
                    new { nlName = name, nlGia = price, nlSoLuong = quantity });
            }
        }

        public List<Ingridient> DbGetAllIngridient()
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                var output =  cnn.Query<Ingridient>("dbo.sp_GetListIngridient").ToList();
                return output;
            }
        }

        public void InitDatabase()
        {
            // This make sure each sqlConection is terminated after usage
            using (IDbConnection connection = new SqlConnection(CnnVal()))
            { 

            }
        }

        internal void DbAddStock(string _nlName, int _nlGia, float _nlSoLuong)
        {
            // This make sure each sqlConection is terminated after usage
            using (IDbConnection connection = new SqlConnection(CnnVal()))
            {
                DateTime dateTime = DateTime.Now;
                connection.Execute(
                    "dbo.sp_AddStock @ngay, @name, @gia, @soluong;",
                    new { ngay = dateTime, name = _nlName, gia = _nlGia, soluong = _nlSoLuong});
            }
        }

        internal void DbRevertAddStock(string _nlName)
        {
            using (IDbConnection connection = new SqlConnection(CnnVal()))
            {
                DateTime dateTime = DateTime.Now;
                connection.Execute(
                    "dbo.sp_RevertAddStock @ngay, @name;",
                    new { ngay = dateTime, name = _nlName});
            }
        }
    }
}
