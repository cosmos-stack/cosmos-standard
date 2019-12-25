using System;
using System.Runtime.ExceptionServices;

namespace Cosmos.Exceptions {
    /// <summary>
    /// Exception helper
    /// </summary>
    public static class ExceptionHelper {
        /// <summary>
        /// Prepare for rethrow
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Exception PrepareForRethrow(Exception exception) {
            ExceptionDispatchInfo.Capture(exception).Throw();

            // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
            //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
            return exception;
        }
    }
}