using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public class SQLiteHepler
    {
        public static readonly string ConnetionString = @"Data Source=C:\temp\2023_11_03_DDD\DDD.db";
        internal static IReadOnlyList<T> Query<T>(string sql, Func<DbDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }
        internal static IReadOnlyList<T> Query<T>(string sql, DbParameter[] parameters, Func<DbDataReader, T> createEntity)
        {
            List<T> list = new List<T>();
            // DB接続する
            using (var connetion = new SQLiteConnection(ConnetionString))
            {
                using (var command = new SQLiteCommand(sql, connetion))
                {
                    connetion.Open();
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (var render = command.ExecuteReader())
                    {
                        while (render.Read())
                        {
                            list.Add(createEntity(render));
                        }

                    }
                }
            }
            return list;
        }


        internal static T Query<T>(string sql, Func<DbDataReader, T> createEntity, T nullEntity)
        {
            return Query<T>(sql, null, createEntity, nullEntity);
        }

        internal static T Query<T>(string sql, DbParameter[] parameters, Func<DbDataReader, T> createEntity, T nullEntity)
        {
            // DB接続する
            using (var connetion = new SQLiteConnection(ConnetionString))
            {
                using (var command = new SQLiteCommand(sql, connetion))
                {
                    connetion.Open();
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (var render = command.ExecuteReader())
                    {
                        while (render.Read())
                        {
                            return createEntity(render);
                        }

                    }
                }
            }
            return nullEntity;
        }

        internal static void Execute(string insert, string update, DbParameter[] parameters)
        {
            using (var connetion = new SQLiteConnection(ConnetionString))
            {
                using (var command = new SQLiteCommand(update, connetion))
                {
                    connetion.Open();
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    if (command.ExecuteNonQuery() < 1)
                    {
                        command.CommandText = insert;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static void Execute(string sql, DbParameter[] parameters)
        {
            using (var connetion = new SQLiteConnection(ConnetionString))
            {
                using (var command = new SQLiteCommand(sql, connetion))
                {
                    connetion.Open();
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void Execute(string sql, DbParameter[] parameters, DbTransaction dbTransaction)
        {
            using (var command = dbTransaction.Connection.CreateCommand())
            {
                command.CommandText = sql;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();                
            }
        }
    }
}
