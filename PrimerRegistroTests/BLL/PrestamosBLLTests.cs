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
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Prestamos prestamos = new Prestamos();

            prestamos.PrestamoID = 1;
            prestamos.PersonaID = 1;
            prestamos.Concepto = "PrestamoTest";
            prestamos.Monto = 1000;
            prestamos.FechaPrestamo = DateTime.Now;
            prestamos.Balance = 1000;
            paso = PrestamosBLL.Guardar(prestamos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso;
            paso = PrestamosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void InsertarTest()
        {
            bool paso;
            Prestamos prestamos = new Prestamos();

            prestamos.PrestamoID = 1;
            prestamos.PersonaID = 1;
            prestamos.Concepto = "PrestamoTest";
            prestamos.Monto = 1000;
            prestamos.FechaPrestamo = DateTime.Now;
            prestamos.Balance = 1000;

            paso = PrestamosBLL.Insertar(prestamos);
            PrestamosBLL.AumentarPrestamos(prestamos.PersonaID, prestamos.Balance);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Prestamos prestamos = new Prestamos();

            prestamos.PrestamoID = 1;
            prestamos.PersonaID = 1;
            prestamos.Monto = 1000;
            prestamos.Balance = 1000;

            var persona = PersonasBLL.Buscar(prestamos.PersonaID);
            decimal balance = persona.Balance;
            PrestamosBLL.Modificar(prestamos);
            PrestamosBLL.AumentarPrestamos(prestamos.PersonaID, prestamos.Balance);
            persona = PersonasBLL.Buscar(prestamos.PersonaID);

            if (persona.Balance == balance)
                paso = false;
            else
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            var persona = PersonasBLL.Buscar(1);
            decimal balance = persona.Balance;
            PrestamosBLL.Eliminar(1);
            persona = PersonasBLL.Buscar(1);

            if (persona.Balance == balance)
                paso = false;
            else
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso;
            var prestamo = PrestamosBLL.Buscar(1);

            if (prestamo != null)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            bool paso;
            var lista = PrestamosBLL.GetList(x => true);

            if (lista != null)
                paso = true;
            else
                paso = false;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void LlenarBalanceTest()
        {
            bool paso;
            Prestamos prestamos = new Prestamos();

            prestamos.PrestamoID = 1;
            prestamos.PersonaID = 1;
            prestamos.Monto = 1000;
            prestamos.Balance = 1000;

            var persona = PersonasBLL.Buscar(prestamos.PersonaID);
            decimal balanceActual = persona.Balance;
            PrestamosBLL.Modificar(prestamos);
            PrestamosBLL.AumentarPrestamos(prestamos.PersonaID, prestamos.Balance);
            persona = PersonasBLL.Buscar(prestamos.PersonaID);

            if (persona.Balance == balanceActual)
                paso = false;
            else
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GuardarInscripcionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoverPrestamoTest()
        {
            bool paso;
            var persona = PersonasBLL.Buscar(1);
            decimal balanceActual = persona.Balance;
            PrestamosBLL.Eliminar(1);
            persona = PersonasBLL.Buscar(1);

            if (persona.Balance == balanceActual)
                paso = false;
            else
                paso = true;

            Assert.AreEqual(paso, true);
        }
    }
}