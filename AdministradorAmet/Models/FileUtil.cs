﻿using Microsoft.JSInterop;

namespace AdministradorAmet.Models
{
    public static class FileUtil
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
           => js.InvokeAsync<object>("saveAsFile", filename, Convert.ToBase64String(data));
    }

}
