using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.EntityMapping;
using Domain.Entities;
using Domain.Entities.Email;

namespace Data.Contexts
{
    public class GenericoDbContext : DbContext
    {
        public GenericoDbContext()
            : base(nameOrConnectionString: "EcoAprenderConnection")
        { }

        public DbSet<Escola> Escola { get; set; }

        public DbSet<Atividade> Atividade { get; set; }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Calendario> Calendario { get; set; }

        public DbSet<Cardapio> Cardapio { get; set; }

        public DbSet<Comunicado> Comunicado { get; set; }

        public DbSet<ComunicadoLeituraUsuario> ComunicadoLeituraUsuario { get; set; }

        public DbSet<ComunicadoConfirmarUsuario> ComunicadoConfirmarUsuario { get; set; }

        public DbSet<Perfil> Perfil { get; set; }

        public DbSet<ChatMensagem> ChatMensagem { get; set; }

        public DbSet<Chat> Chat { get; set; }

        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }

        public DbSet<Grupo> Grupo { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Video> Video { get; set; }

        public DbSet<Sugestao> Sugestao { get; set; }

        public DbSet<SugestaoResposta> SugestaoResposta { get; set; }

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Parentesco> Parentesco { get; set; }

        public DbSet<AlunoPais> AlunoPais { get; set; }

        public DbSet<Medicamento> Medicamento { get; set; }

        public DbSet<MedicamentoRealizado> MedicamentoRealizado { get; set; }

        public DbSet<RefeicaoTipo> RefeicaoTipo { get; set; }

        public DbSet<RefeicaoStatus> RefeicaoStatus { get; set; }

        public DbSet<RefeicaoAlimento> RefeicaoAlimento { get; set; }

        public DbSet<Refeicao> Refeicao { get; set; }

        public DbSet<Sono> Sono { get; set; }

        public DbSet<Evacuacao> Evacuacao { get; set; }

        public DbSet<Leite> Leite { get; set; }

        public DbSet<FaleConosco> FaleConosco { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType(("varchar")));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(100));

            modelBuilder.Configurations.Add(new EscolaMap());
            modelBuilder.Configurations.Add(new AtividadeMap());
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new CalendarioMap());
            modelBuilder.Configurations.Add(new CardapioMap());
            modelBuilder.Configurations.Add(new ComunicadoMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new ChatMensagemMap());
            modelBuilder.Configurations.Add(new ChatMap());
            modelBuilder.Configurations.Add(new GrupoUsuarioMap());
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new VideoMap());
            modelBuilder.Configurations.Add(new SugestaoMap());
            modelBuilder.Configurations.Add(new SugestaoRespostaMap());
            modelBuilder.Configurations.Add(new ComunicadoLeituraUsuarioMap());
            modelBuilder.Configurations.Add(new ComunicadoConfirmarUsuarioMap());
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new ParentescoMap());
            modelBuilder.Configurations.Add(new AlunoPaisMap());
            modelBuilder.Configurations.Add(new MedicamentoMap());
            modelBuilder.Configurations.Add(new MedicamentoRealizadoMap());
            modelBuilder.Configurations.Add(new RefeicaoAlimentoMap());
            modelBuilder.Configurations.Add(new RefeicaoStatusMap());
            modelBuilder.Configurations.Add(new RefeicaoTipoMap());
            modelBuilder.Configurations.Add(new RefeicaoMap());
            modelBuilder.Configurations.Add(new LeiteMap());
            modelBuilder.Configurations.Add(new SonoMap());
            modelBuilder.Configurations.Add(new EvacuacaoMap());
            modelBuilder.Configurations.Add(new FaleConoscoMap());
        }
    }
}
