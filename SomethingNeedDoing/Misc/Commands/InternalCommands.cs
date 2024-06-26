﻿using System;
using System.Linq;

namespace SomethingNeedDoing.Misc.Commands;

public class InternalCommands
{
    internal static InternalCommands Instance { get; } = new();

    public string? InternalGetMacroText(string name)
    {
        return Service.Configuration
            .GetAllNodes()
            .OfType<MacroNode>()
            .FirstOrDefault(node =>
                string.Equals(node.Name.Trim(), name.Trim(), StringComparison.InvariantCultureIgnoreCase))?
            .Contents
            .Split(["\r\n", "\r", "\n"], StringSplitOptions.None)
            .Select(line => $"  {line}")
            .Join('\n');
    }

    public void SetSNDProperty(string key, string value) => Service.Configuration.SetProperty(key, value);
    public object GetSNDProperty(string key) => Service.Configuration.GetProperty(key);
}