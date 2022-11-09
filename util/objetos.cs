namespace webapp.objetos
{
    public class Cliente
    {
        private string name_table = "dbo.cliente";
        private int id;
        private string? nome;
        private string? email;
        private string? fone;
        private string? endereco;

        public int Id 
        {
            get => this.id;
            set{ this.id = value;}
        }
        public string Nome 
        {
            get => this.nome;
            set{ this.nome = value;}
        }
        public string Email 
        {
            get => this.email;
            set{ this.email = value;}
        }
        public string Fone 
        {
            get => this.fone;
            set{ this.fone = value;}
        }
        public string Endereco 
        {
            get => this.endereco;
            set{ this.endereco = value;}
        }
        public string Name_table {get => this.name_table;}
    }
}