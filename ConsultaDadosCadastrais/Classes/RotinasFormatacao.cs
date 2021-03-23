using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaDadosCadastrais.Classes
{
    public class RotinasFormatacao
    {
        public static string FormataCep(string cep) 
        {
            try
            {
                if (cep != null && cep != "" && cep != " ")
                {
                    return Convert.ToUInt64(cep).ToString(@"00000\-000");
                }
                else 
                {
                    return cep;
                }
            }
            catch
            {
                return cep;
            }
        }

        public static string FormataTelefone(string telefone) 
        {
            try
            {
                if (telefone != null && telefone != "" && telefone != " ")
                {
                    if (telefone.Length == 8) //32246872 //992266794
                    {
                        return Convert.ToUInt64(telefone).ToString(@"0000\-0000");
                    }
                    else if (telefone.Length == 9)
                    {
                        return Convert.ToUInt64(telefone).ToString(@"00000\-0000");
                    }
                    else if (telefone.Length == 11)
                    {
                        return Convert.ToUInt64(telefone).ToString(@"\(00\)00000\-0000");
                    }
                    else
                    {
                        return Convert.ToUInt64(telefone).ToString(@"\(00\)0000\-0000");
                    }
                }
                else 
                {
                    return telefone;
                }
            }
            catch
            {
                return telefone;
            }
        }
        public static string FormataCpf(string cpf) 
        {
            try
            {
                if (cpf != null && cpf != "" && cpf != " ")
                {
                    return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                }
                else 
                {
                    return cpf;
                }
                    
            }
            catch
            {
                return cpf;
            }
        }
    }
}