﻿using drugovich.autopecas.core.Common;

namespace drugovich.autopecas.core;

public class Grupo : BaseEntity
{
    public string Nome { get; set; }

    public List<Cliente> Clientes { get; set; }
    
}