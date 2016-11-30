﻿using DebuggerEngine.Interop;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinDbgEx.Models;

namespace WinDbgEx.Commands {
    static class DebugCommands {
		public static DelegateCommandBase Go { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("g"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase StepOver { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("p"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase StepInto { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("t"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase StepOut { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("gu"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase Restart { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute(".restart"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase StepToCall { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("gc"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase StepToBranch { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("ph"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase StepToReturn { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Execute("pt"), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase Break { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Break(), context => context?.Debug.Status == DEBUG_STATUS.GO);
		public static DelegateCommandBase Stop { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Stop(), context => context != null && context.Debug.Status != DEBUG_STATUS.NO_DEBUGGEE);

		public static DelegateCommandBase Detach { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.Detach(), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
		public static DelegateCommandBase DetachAll { get; } = new DelegateCommand<AppManager>(context => context.Debug.Debugger.DetachAll(), context => context?.Debug.Status == DEBUG_STATUS.BREAK);
	}
}
