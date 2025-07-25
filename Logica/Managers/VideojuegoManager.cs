﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaJuegos.Models;
using Logica.Contexto;

namespace Logica.Managers
{
    public class VideojuegoManager
    {
        public static Videojuego ObtenerVideojuego(int id)
        {
            using (Conexion db = new Conexion())
            {

                //Obtener el id del producto desde la base de datos
                Videojuego usuario = db.Videojuegos.FirstOrDefault(a => a.idVideojuego == id);
                return usuario;
            }
        }
        public static Videojuego ObtenerDatosUnUsuario(int id)
        {
            using (var db = new Conexion())
            {

                var usuario = db.Videojuegos.SingleOrDefault(p => p.idVideojuego == id);

                return usuario;
            }
        }
        public static Videojuego GuardarVideojuegos(int id, string titulo, string genero, string plataforma, int PEGI)
        {
            using (var db = new Conexion())
            {
                if (db.Videojuegos.Any(u => u.Titulo == titulo && u.idVideojuego != id))
                {
                    throw new Exception("El videojuego ya está en la base de datos");
                }

                var videojuego = db.Videojuegos.FirstOrDefault(a => a.idVideojuego == id);

                if (videojuego != null)
                {
                    // Editar videojuego existente
                    videojuego.Titulo = titulo;
                    videojuego.Genero = genero;
                    videojuego.Plataforma = plataforma;
                    videojuego.PEGI = PEGI;
                    db.SaveChanges();
                    return videojuego;
                }

                // Crear nuevo videojuego
                videojuego = new Videojuego()
                {
                    idVideojuego = id,
                    Titulo = titulo,
                    Genero = genero,
                    Plataforma = plataforma,
                    PEGI = PEGI
                };

                db.Videojuegos.Add(videojuego);
                db.SaveChanges();

                return videojuego;
            }
        }

        public static List<Videojuego> ListarVideojuegos()
        {
            using (var cn = new Conexion())
            {
                List<Videojuego> usuarios = cn.Videojuegos.ToList();
                return usuarios;

            }
        }
        public static void EliminarVideojuego(int id)
        {
            using (var db = new Conexion())
            {
                var usuario = db.Videojuegos.FirstOrDefault(a => a.idVideojuego == id);
                if (usuario != null)
                {
                    db.Videojuegos.Remove(usuario);
                    db.SaveChanges();
                }
                db.SaveChanges();
            }
        }
    }
}