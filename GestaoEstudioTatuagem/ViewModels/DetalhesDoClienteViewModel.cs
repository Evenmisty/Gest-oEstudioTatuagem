using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestaoEstudioTatuagem.Models;
using System.Collections.ObjectModel;

namespace GestaoEstudioTatuagem.ViewModels;

public partial class DetalhesDoClienteViewModel : ObservableObject
{
    [ObservableProperty]
    private Clientes client;

    [ObservableProperty]
    private ObservableCollection<Sessao> tattooHistory;

    [ObservableProperty]
    private ObservableCollection<ProntuarioEletronico> medicalRecords;

    [ObservableProperty]
    private bool isPersonalInfoVisible = true;

    [ObservableProperty]
    private bool isTattooHistoryVisible;

    [ObservableProperty]
    private bool isAnamnesisVisible;

    [ObservableProperty]
    private bool isRecordsVisible;

    public DetalhesDoClienteViewModel(Clientes cliente)
    {
        this.client = cliente;


        TattooHistory = new ObservableCollection<Sessao>
        {
            new Sessao { DescricaoTatuagem = "Dragão no braço", DataSessao = DateTime.Now.AddMonths(-2) },
            new Sessao { DescricaoTatuagem = "Rosa no ombro", DataSessao = DateTime.Now.AddMonths(-5) }
        };

        MedicalRecords = new ObservableCollection<ProntuarioEletronico>
        {
            new ProntuarioEletronico { DetalhesProcedimento = "Cuidados pós-tatuagem", DataRegistro = DateTime.Now.AddMonths(-2) }
        };
    }

    [RelayCommand]
    private void ShowPersonalInfo() => SetSectionVisibility(true, false, false, false);

    [RelayCommand]
    private void ShowTattooHistory() => SetSectionVisibility(false, true, false, false);

    [RelayCommand]
    private void ShowAnamnesis() => SetSectionVisibility(false, false, true, false);

    [RelayCommand]
    private void ShowRecords() => SetSectionVisibility(false, false, false, true);

    private void SetSectionVisibility(bool personal, bool tattoo, bool anamnesis, bool records)
    {
        IsPersonalInfoVisible = personal;
        IsTattooHistoryVisible = tattoo;
        IsAnamnesisVisible = anamnesis;
        IsRecordsVisible = records;
    }

    [RelayCommand]
    private void EditClient() { }

    [RelayCommand]
    private void ScheduleSession() { }

    [RelayCommand]
    private void ViewAnamnesis() { }
}
