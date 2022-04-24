using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios;

public class CompraRepositorio : ICompraRepositorio
{
    private string CadenaConexion;

    public CompraRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    public async Task<bool> Comprar(Compra compra)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO compra (Id, Cliente, Fecha, Subtotal, Impuesto, Total, CodigoProducto) VALUES (@Id, @Cliente, @Fecha, @Subtotal, @Impuesto, @Total, @CodigoProducto)";
            resultado = await conexion.ExecuteAsync(sql, compra);
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Compra>> GetLista()
    {
        IEnumerable<Compra> lista = new List<Compra>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM compra;";
            lista = await conexion.QueryAsync<Compra>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
    }

    public async Task<Compra> GetPorCodigo(string codigoProducto)
    {
        Compra comp = new Compra();
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM compra WHERE CodigoProducto = @CodigoProducto;";
            comp = await conexion.QueryFirstAsync<Compra>(sql, new { codigoProducto });
        }
        catch (Exception)
        {
        }
        return comp;
    }

  
}
