using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PrimerRegistro.BLL;
using PrimerRegistro.Models;
using PrimerRegistro.Dal;

namespace PrimerRegistro.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Personas personas = new Personas();

            personas.PersonaID = 0;
            personas.Nombre = "GuardarTest";
            personas.Cedula = "00000000";
            personas.Telefono = "11111111111";
            personas.Direccion = "GuardarTestDireccion";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;

            paso = PersonasBLL.Guardar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso;
            paso = PersonasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Personas personas = new Personas();

            personas.PersonaID = 0;
            personas.Nombre = "InsertarTest";
            personas.Cedula = "1111111111";
            personas.Telefono = "2222222222";
            personas.Direccion = "InsertarTestDireccion";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonasBLL.Guardar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Personas personas = new Personas();

            personas.PersonaID = 1;
            personas.Nombre = "ModificarTest";
            personas.Cedula = "333333333";
            personas.Telefono = "44444444";
            personas.Direccion = "ModificarTestDireccion";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonasBLL.Modificar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;

            if (PersonasBLL.Eliminar(1))
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso;
            var persona = PersonasBLL.Buscar(1);
            if (persona != null)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso;
            var lista = PersonasBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }
    }
}