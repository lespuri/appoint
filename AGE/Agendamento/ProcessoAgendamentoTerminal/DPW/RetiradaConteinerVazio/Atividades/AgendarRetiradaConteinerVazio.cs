using AGE.Agendamento.Atividades;
using AGE.Agendamento.DPW.Entidades;
using AGE.Agendamento.DPW.RetiradaVazio.Helpers;
using AGE.Agendamento.ProcessoAgendamentoTerminal.DPW.ConteinerVazio.Exceptions;
using AGE.Exceptions;
using AGE.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGE.Agendamento.DPW.Atividades
{
    public class AgendarRetiradaConteinerVazio : OperarSistemaAgendamento
    {
        private RetiradaConteinerVazioRepositorio aRetiradaConteinerVazioRepositorio;

        private RetiradaConteinerVazio aRetiradaConteinerVazio;
        public AgendarRetiradaConteinerVazio(RetiradaConteinerVazio prRetiradaConteinerVazio) : base()
        {
            aDriver.Navigate().GoToUrl("http://www.embraportonline.com.br/");
            aRetiradaConteinerVazioRepositorio = new RetiradaConteinerVazioRepositorio();
            aRetiradaConteinerVazio = prRetiradaConteinerVazio;
        }

        #region Métodos privados
        private bool RealizarLogin()
        {
            try
            {
                if (aDriver.Url != "http://www.embraportonline.com.br/Main")
                {
                    Log.Debug("Iniciou Login");
                    preencherCampo(XPathRetiradaVazioDPW.USARIO_NOME, obterValorSetting("usuarioDPW"));
                    preencherCampo(XPathRetiradaVazioDPW.USARIO_SENHA , obterValorSetting("senhaDPW"));
                    clicar(XPathRetiradaVazioDPW.BOTAO_LOGIN);
                    Log.Debug("Terminou Login");
                }
            }
            catch (NotFoundException exnf)
            {                
                throw new CustomException(exnf.Message, exnf);                
            }
            catch(Exception ex)
            {
                throw new CustomException(ex.Message, ex);
            }

            return operacaoSucesso;
        }
        private void AcessarAgendmentoRapido()
        {
            try
            {                
                if (aDriver.FindElements(By.TagName("div") ).Where(x=> "PopupMensagemTela-".Contains(x.GetAttribute("id")) ).FirstOrDefault() != null)
                {                                        
                    aDriver.FindElements(By.TagName("button")).Where(x=>x.GetAttribute("id").StartsWith("btnPopupMensagemTela-") ).FirstOrDefault().Click() ;
                }

                aDriver.FindElements(By.TagName("a")).Where(x => x.Text == "  Agendamento Rápido").FirstOrDefault().Click();
                Log.Debug("Acessou menu agendamento rapido");

            }
            catch(NotFoundException ex)
            {
                throw new CustomException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, ex);
            }

        }
        private void PreencherTransportadora()
        {
            try
            {
                var cnpjTranportadora = obterValorSetting("cnpjTransportadora");
                preencherCampo(XPathRetiradaVazioDPW.AC_TRANSPORTADORA, cnpjTranportadora);
                preencherCampo(XPathRetiradaVazioDPW.AC_TRANSPORTADORA, Keys.ArrowDown + Keys.Enter);

                if (aDriver.FindElements(By.TagName("Label")).Where(x => x.Text.StartsWith(cnpjTranportadora)).FirstOrDefault() == null)
                    throw new Exception("CNPJ Transportadora nao encontrado : " + cnpjTranportadora);
                                    
                Log.Debug("Preencheu campo transportadora");
            }
            catch (NotFoundException ex)
            {
                throw new SistemaException(ex, true);
            }            
            catch (Exception ex)
            {
                throw new SistemaException(ex, true);
            }
        }
        private void SelecionarComboGate()
        {
            try
            {
                preencherCampo(XPathRetiradaVazioDPW.CB_GATE, Keys.ArrowDown);                    
                Log.Debug("Selecionou combo gate");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, ex);
            }
        }
        private void AdicionarTransacao()
        {
            try
            {
                clicar(XPathRetiradaVazioDPW.BT_ADICIONAR_CONTEINER);                    
                Log.Debug("Clicou em adicionar transação");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void SelecionarTipoMovimento()
        {
            try
            {
                preencherCampo(XPathRetiradaVazioDPW.CB_TIPO_MOVIMENTO, Keys.ArrowDown);                    
                Log.Debug("Selecinou a combo tipo movimento");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, ex);
            }
        }
        private void PreencherBooking(string prBooking)
        {
            try
            {
                preencherCampo(XPathRetiradaVazioDPW.AC_BOOKING, prBooking);
                preencherCampo(XPathRetiradaVazioDPW.AC_BOOKING, Keys.ArrowDown + Keys.Enter);
                    
                if (aDriver.FindElements(By.TagName("Label")).Where(x => x.Text == prBooking).FirstOrDefault() == null)
                    throw new BookingNaoEncontradoException(string.Format("Booking {0} não encontrado", prBooking), aRetiradaConteinerVazio);

                Log.Debug("Selecionou o booking");
            }
            catch (BookingNaoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void ClicarSelecionarTransacao()
        {
            try
            {
                clicar(XPathRetiradaVazioDPW.BT_SELECINAR_TRANSACAO);                    
                Log.Debug("Clicou no botao Selecionar da tela transação");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message,ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void ClicarJanelas()
        {
            try
            {                
                clicar(XPathRetiradaVazioDPW.BT_JANELAS);                
                Log.Debug("Clicou no botao Janelas");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message,ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void SelecionarJanelas(DateTime prDataHoraAgendamento)
        {
            try
            {
                var selDiaJanela = new SelectElement(aDriver.FindElement(By.Id("sDiaJanela")));
                var selJanela = new SelectElement(aDriver.FindElement(By.Id("sJanela")));

                var arrDiaJanela = selDiaJanela.Options;
                var arrJanela = selJanela.Options;

                var lDiaJanela = arrDiaJanela.Where(x => x.Text == string.Format("{0:dd/MM/yyyy}", prDataHoraAgendamento)).FirstOrDefault();
                var lJanela = arrJanela.Where(x => x.Text.Split('|')[0].Trim() == string.Format("{0:HH:mm}", prDataHoraAgendamento)).FirstOrDefault();

                if (lDiaJanela == null || lJanela == null)
                    throw new JanelaIndisponivelException("Janela indisponível",aRetiradaConteinerVazio);

                selDiaJanela.SelectByIndex( arrDiaJanela.IndexOf(lDiaJanela));
                selJanela.SelectByIndex(arrJanela.IndexOf(lJanela));                
                    
                Log.Debug("Selecionou o Horario da janela");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message,ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void PreencherPlacaVeiculo(string prPlacaVeiculo)
        {
            try
            {
                preencherCampo(XPathRetiradaVazioDPW.PLACA_MOTORISTA, prPlacaVeiculo);                    
                Log.Debug("Preencheu a placa do veiculo");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message,ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void PreencherCPFMotorista(string prCPF)
        {
            try
            {
                preencherCampo(XPathRetiradaVazioDPW.AC_CPF_MOTORISTA, prCPF);
                preencherCampo(XPathRetiradaVazioDPW.AC_CPF_MOTORISTA, Keys.ArrowDown + Keys.Enter);
                    
                if (aDriver.FindElements(By.TagName("Label")).Where(x => x.Text.Contains(prCPF)).FirstOrDefault() == null)
                    throw new MotoristaNaoEncontradolException("Motorista nao encontrado", aRetiradaConteinerVazio);

                Log.Debug("Selecionoou o CPF do Motorista");
            }
            catch (NotFoundException ex)
            {
                throw new CustomException(ex.Message,ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message,ex);
            }
        }
        private void encerrarNavegacao(string messagem = "")
        {
            aDriver.Close();
            aDriver.Quit();
            aDriver.Dispose();

            Log.Debug(messagem);
        }

        private void VerificarClicarMensagemBDCC()
        {
            if (aDriver.FindElement(By.Id("lblTitleCadastroMotorista")).Displayed)
                aDriver.FindElement(By.Id("btcloseCadastroMotoristaModal")).Click();
        }
        private void ClicarAgendar()
        {
            try
            {
                if (!bool.Parse(obterValorSetting("modeDebug")))
                {
                    //clicar(XPathRetiradaVazioDPW.BT_AGENDAR);

                    aRetiradaConteinerVazio.Status = (int)RetiradaConteinerVazio.eStatus.Agendado;
                    aRetiradaConteinerVazioRepositorio.Update(aRetiradaConteinerVazio);

                    Log.Debug("Clicou no botao agendar");
                }
                else
                {
                    Log.Debug("Não clicou no botao agendar. Modo debug ativo");
                }
            }
            catch (NotFoundException ex)
            {
                throw new SistemaException(ex);
            }
            catch (SistemaException ex)
            {
                throw new SistemaException(ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, ex);
            }
        }
        #endregion

        public bool agendar()
        {
            Log.Debug("#######INICIO AGENDAMENTO DE ENTREGA DE VAZIO PARA O BOOKING -> " + aRetiradaConteinerVazio.Reserva + " #########");
            try
            {
                RealizarLogin();
                AcessarAgendmentoRapido();
                PreencherTransportadora();
                SelecionarComboGate();
                AdicionarTransacao();
                SelecionarTipoMovimento();
                PreencherBooking(aRetiradaConteinerVazio.Reserva);
                ClicarSelecionarTransacao();
                ClicarJanelas();
                SelecionarJanelas(aRetiradaConteinerVazio.DataHora);
                PreencherPlacaVeiculo(aRetiradaConteinerVazio.PlacaVeiculo);
                PreencherCPFMotorista(aRetiradaConteinerVazio.CPFMotorista);
                VerificarClicarMensagemBDCC();
                ClicarAgendar();
            }
            catch
            {
                //aRetiradaConteinerVazio.Status = (int)RetiradaConteinerVazio.eStatus.Erro;
                //aRetiradaConteinerVazioRepositorio.Update(aRetiradaConteinerVazio);
            }
            finally
            {
                encerrarNavegacao("####### FIM AGENDAMENTO DE ENTREGA DE VAZIO PARA O BOOKING -> " + aRetiradaConteinerVazio.Reserva + " #########");                
            }

            return operacaoSucesso;
        }

        
    }
}
