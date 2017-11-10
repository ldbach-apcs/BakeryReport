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

        internal void DbAddIngridient(String name, int price, float quantity) {
            // This make sure each sqlConection is terminated after usage
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                cnn.Execute(
                    "dbo.sp_AddIngridient @nlName, @nlGia, @nlSoLuong", 
                    new { nlName = name, nlGia = price, nlSoLuong = quantity });
            }
        }

        internal List<Cake> DbGetListCake()
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                var output = cnn.Query<Cake>("dbo.sp_GetCake").ToList();
                return output;
            }
        }

        internal List<Ingridient> DbGetStockIngridient()
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                var output =  cnn.Query<Ingridient>("dbo.sp_GetStockIngridient").ToList();
                return output;
            }
        }

        internal List<Ingridient> DbGetRecipeIngridient()
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                var output = cnn.Query<Ingridient>("dbo.sp_GetRecipeIngridient").ToList();
                return output;
            }
        }

        internal void InitDatabase()
        {
            // Nothing to see here :)
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

        internal void DbAddRecipe (string bName, int bGia, List<Ingridient> ingridients)
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                // Add cake name first
                cnn.Execute(
                    "dbo.sp_AddCake @name, @gia",
                    new { name = bName, gia = bGia });

                // Then add recipe
                foreach (Ingridient ing in ingridients)
                {
                    cnn.Execute(
                        "dbo.sp_AddToRecipe @banh, @nlName, @nlDinhLuong",
                        new { banh = bName,
                            nlName = ing.nlName,
                            nlDinhLuong = ing.nlSoLuong });
                }
            }
        }

        internal void DbChangePrice(Cake cake)
        {
            using (IDbConnection cnn = new SqlConnection(CnnVal()))
            {
                cnn.Execute(
                    "dbo.sp_ChangePrice @name, @newPrice",
                    new { name = cake.bName, newPrice = cake.bGiaBan });
            }
        }
    }
}
