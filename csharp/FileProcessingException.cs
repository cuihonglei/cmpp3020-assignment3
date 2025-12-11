using System;

public class FileProcessingException : Exception
{
    public FileProcessingException(string message) : base(message) { }
}