using System.Linq;
using System;
using System.Collections.Generic;

namespace Proyecto_Final
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que crea una instancia "Producto".
    /// </summary>
    public class ProductoHandler : BaseHandler
    {
        private string[] allowedStatus;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string[] AllowedStatus {get; set;}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public ProductoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"producto"};
            this.AllowedStatus = new string[] {"STATUS_PRODUCT_RESPONSE",
                                                "STATUS_PRODUCT_TYPE",
                                                "STATUS_PRODUCT_DESCRIPTION",
                                                "STATUS_PRODUCT_LOCATION",
                                                "STATUS_PRODUCT_MONETARY_VALUE",
                                                "STATUS_PRODUCT_RESPONSE_MONETARY_VALUE",
                                                "STATUS_PRODUCT_QUANTITY",
                                                "STATUS_PRODUCT_END"
                                                };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="responder"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string responder)
        {
            string check = Singleton<StatusManager>.Instance.CheckStatus(message.UserId);
            if (this.CanHandle(message) || (this.AllowedStatus.Contains(check)))
            {
                if (check == "STATUS_IDLE")
                {   
                    responder = "¿Desea crear un producto? Y/N";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_RESPONSE");
                    return true;
                }
                else if (check == "STATUS_PRODUCT_RESPONSE")
                {
                    if(message.Text == "Y")
                    {
                        responder = "Introduzca el nombre del producto:";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_TYPE");
                        return true;
                    }
                    else
                    {
                        responder = "Operación abortada correctamente.";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                        return true;
                    }                
                }
                else if (check == "STATUS_PRODUCT_TYPE")
                {
                    responder = "Introduzca el tipo de producto (Tela,Metal,Cerámica,etc...):";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_DESCRIPTION");
                    Singleton<CreadorProducto>.Instance.AgregarDiccionarioNombre(message.UserId,message.Text);
                    return true;
                }
                else if (check == "STATUS_PRODUCT_DESCRIPTION")
                {
                    responder = "Introduzca una descripción basica del producto:";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_LOCATION");
                    Singleton<CreadorProducto>.Instance.AgregarDiccionarioTipo(message.ChatId,message.Text);
                    return true;
                }
                else if (check == "STATUS_PRODUCT_LOCATION")
                {
                    responder = "Introduzca la ubicación del producto:";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_MONETARY_VALUE");
                    Singleton<CreadorProducto>.Instance.AgregarDiccionarioDescripcion(message.ChatId,message.Text);
                    return true;
                }
                else if (check == "STATUS_PRODUCT_MONETARY_VALUE")
                {
                    responder = "¿En qué moneda desea registrar el valor? \nIngrese \"1\" para dolares estadounidenses.\nIngrese \"2\" para pesos uruguayos.";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_RESPONSE_MONETARY_VALUE");
                    Singleton<CreadorProducto>.Instance.AgregarDiccionarioUbicacion(message.ChatId,message.Text);
                    return true;
                }
                else if (check == "STATUS_PRODUCT_RESPONSE_MONETARY_VALUE")
                {
                    if(message.Text == "1")
                    {
                        responder = "Se ha asignado al precio en dólares.\nIndique el valor unitario del producto:";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_QUANTITY");
                        Singleton<CreadorProducto>.Instance.AgregarDiccionarioMoneda(message.ChatId,message.Text);
                        return true;
                    }
                    else if (message.Text == "2")
                    {
                        responder = "Se ha asignado al precio en pesos uruguayos.\nIndique el valor unitario del producto:";
                        Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.ChatId, "STATUS_PRODUCT_QUANTITY");
                        Singleton<CreadorProducto>.Instance.AgregarDiccionarioMoneda(message.ChatId,message.Text);
                        return true;
                    }
                    else
                    {
                        responder = "No entendí, por favor, responda \"1\" para dólares estadounidenses o ingrese \"2\" para pesos uruguayos";
                        return true;
                    }
                }
                else if (check == "STATUS_PRODUCT_QUANTITY")
                {
                    responder = "Introduzca la cantidad almacenada de su producto";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_PRODUCT_END");
                    Singleton<CreadorProducto>.Instance.AgregarDiccionarioValor(message.ChatId,message.Text);
                    return true;
                }
                else if (check == "STATUS_PRODUCT_END")
                {
                    responder = "Se ha registrado su producto correctamente. Puede utilizar otros comandos ahora.";
                    Singleton<StatusManager>.Instance.AgregarEstadoUsuario(message.UserId, "STATUS_IDLE");
                    Singleton<CreadorProducto>.Instance.AgregarDiccionarioCantidad(message.ChatId,message.Text);
                    Singleton<CreadorProducto>.Instance.CrearProducto(message.ChatId);
                    return true;
                }
            }
        responder = string.Empty;
        return false;
        }
    }
}