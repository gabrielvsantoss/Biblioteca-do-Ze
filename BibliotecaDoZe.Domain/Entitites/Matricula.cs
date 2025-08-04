﻿using AcademiaDoZe.Domain.Enums;
using AcademiaDoZe.Domain.ValueObjects;
using AcademiaDoZe.Dominio.Exceptions;


using AcademiaDoZe.Dominio.Services;
namespace AcademiaDoZe.Domain.Entities
{
    public class Matricula : Entity
    {
        //Gabriel Velho dos Santos

        public Aluno AlunoMatricula { get; private set; }
        public EMatriculaPlano Plano { get; private set; }
        public DateOnly DataInicio { get; private set; }
        public DateOnly DataFim { get; private set; }
        public string Objetivo { get; private set; }
        public EMatriculaRestricoes RestricoesMedicas { get; private set; }
        public string ObservacoesRestricoes { get; private set; }
        public Arquivo LaudoMedico { get; private set; }
     
        private Matricula(Aluno alunoMatricula, EMatriculaPlano plano, DateOnly dataInicio, DateOnly dataFim, string objetivo, EMatriculaRestricoes restricoesMedicas, Arquivo laudoMedico, string observacoesRestricoes = "")
        : base()
        {
            AlunoMatricula = alunoMatricula;
            Plano = plano;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Objetivo = objetivo;
            RestricoesMedicas = restricoesMedicas;
            LaudoMedico = laudoMedico;
            ObservacoesRestricoes = observacoesRestricoes;
        }
        public static Matricula Criar(Aluno alunoMatricula, EMatriculaPlano plano, DateOnly dataInicio, DateOnly dataFim, string objetivo, EMatriculaRestricoes restricoesMedicas, Arquivo laudoMedico, string
        observacoesRestricoes = "")
        {
          
            if (alunoMatricula == null) throw new DomainException("ALUNO_INVALIDO");
            if (alunoMatricula.DataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-16)) && laudoMedico == null) throw new DomainException("MENOR16_LAUDO_OBRIGATORIO");
            if (!Enum.IsDefined(plano)) throw new DomainException("PLANO_INVALIDO");
            if (dataInicio == default) throw new DomainException("DATA_INICIO_OBRIGATORIO");
            // dataFim
            if (NormalizadoService.TextoVazioOuNulo(objetivo)) throw new DomainException("OBJETIVO_OBRIGATORIO");
            objetivo = NormalizadoService.LimparEspacos(objetivo);
            if (restricoesMedicas != EMatriculaRestricoes.None && laudoMedico == null) throw new DomainException("RESTRICOES_LAUDO_OBRIGATORIO");
            observacoesRestricoes = NormalizadoService.LimparEspacos(observacoesRestricoes);
      
            return new Matricula(alunoMatricula, plano, dataInicio, dataFim, objetivo, restricoesMedicas, laudoMedico, observacoesRestricoes);
        }
    }
}