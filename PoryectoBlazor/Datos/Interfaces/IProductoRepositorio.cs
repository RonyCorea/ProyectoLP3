﻿using Modelos;

namespace Datos.Interfaces;

public interface IProductoRepositorio
{
    Task<bool> Nuevo(Producto producto);
    Task<bool> Actualizar(Producto producto);
    Task<bool> Eliminar(Producto producto);
    Task<IEnumerable<Producto>> GetLista();
    Task<Producto> GetPorCodigo(string codigo);

}

