namespace APollPoll.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataLayerScaffold : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 50),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        IsMultipleChoice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
        }
    }
}
