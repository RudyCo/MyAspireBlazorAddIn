/* Copyright(c) Maarten van Stam. All rights reserved. Licensed under the MIT License. */
/**
 * JavaScript Initializers
 * JavaScript (JS) initializers execute logic before and after a Blazor app loads. JS initializers are useful in the following scenarios:
 * - Customizing how a Blazor app loads.
 * - Initializing libraries before Blazor starts up.
 * - Configuring Blazor settings.
 */
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
/**
 * beforeStart(options, extensions):
 *
 * Called before Blazor starts.
 * For example, beforeStart is used to customize the loading process, logging level, and other options specific to the hosting model.
 * @param  {} wasmoptions
 * @param  {} extensions
 */
export function beforeWebAssemblyStart(wasmoptions, extensions) {
    return __awaiter(this, void 0, void 0, function* () {
        console.log("We are now entering function: beforeWebAssemblyStart");
        Office.onReady((info) => {
            // Check that we loaded into Excel.
            if (info.host === Office.HostType.Excel) {
                console.log("We are now hosting in Excel.");
            }
            else {
                console.log("We are now hosting in The Browser (of your choice).");
            }
            console.log("Office onReady.");
        });
    });
}
/**
 * afterStarted: Called after Blazor is ready to receive calls from JS.
 * For example, afterStarted is used to initialize libraries by making JS interop calls and registering custom elements.
 * The Blazor instance is passed to afterStarted as an argument.
 * @param  {} blazor
 */
export function afterWebAssemblyStarted(blazor) {
    return __awaiter(this, void 0, void 0, function* () {
        console.log("We are now entering function: afterWebAssemblyStarted");
    });
}
