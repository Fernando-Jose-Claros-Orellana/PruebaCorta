CREATE DATABASE PruebaCorta;

USE PruebaCorta;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50) NOT NULL,
    Contrasena VARCHAR(50) NOT NULL
);

CREATE TABLE Preguntas (
    Id INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Pregunta TEXT NOT NULL,
    Estado INT
);

CREATE TABLE Respuestas (
    Id INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL,
    IdPregunta INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Respuesta TEXT NOT NULL
);

