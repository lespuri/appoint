using AGE.Agendamento.DPW.Entidades;
using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGE.Relatorio.ProgramacaoDiaria.Atividades
{
    public class GerarRelatorioProgramacaoDiaria
    {
        public GerarRelatorioProgramacaoDiaria()
        {

        }

        public void GerarRelatorio(DateTime prData)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("ProgramacaoDiaria");

            RetiradaConteinerVazioRepositorio lRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();
            var lConteinerVazio = lRetiradaConteinerVazioRepositorio.getConteinerVazioAgendadoDoDia(prData);
            var row = 0;
            for (int i = 0; i < 150; i++)
            {
                var col = 0;
                for (int j = 0; j < 10; j++)
                {
                    worksheet.Cells[row, col] = new Cell(" ");
                    col++;
                }
                row++;
            }

            worksheet.Cells[0, 0] = new Cell("Programação diária Retirada de Vazio DPWS");
            
            worksheet.Cells[2, 0] = new Cell("Data");
            worksheet.Cells[2, 1] = new Cell("Booking");            
            worksheet.Cells[2, 2] = new Cell("Placa");
            worksheet.Cells[2, 3] = new Cell("CPF Motorista");

            for (int i = 0; i < lConteinerVazio.Count; i++)
            {
                worksheet.Cells[3 + i, 0] = new Cell(lConteinerVazio[i].DataHora);
                worksheet.Cells[3 + i, 1] = new Cell(lConteinerVazio[i].Reserva);
                worksheet.Cells[3 + i, 2] = new Cell(lConteinerVazio[i].PlacaVeiculo);
                worksheet.Cells[3 + i, 3] = new Cell(lConteinerVazio[i].CPFMotorista);
            }

            var lpath = AppDomain.CurrentDomain.BaseDirectory + "//ProgramacaoDiaria.xls";
            workbook.Worksheets.Add(worksheet);
            workbook.Save(lpath);
        }
    }
}
