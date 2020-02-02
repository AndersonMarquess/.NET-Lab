select * from GalleryImages;

INSERT INTO 
	GalleryImages (Title, Created, [Url]) 
VALUES 
	('Aprendendo PHP', GETDATE(), '/images/php-1.jpg'),
	('Praticando PHP', GETDATE(), '/images/php-2.jpg'),
	('Resultado da minificação', GETDATE(), '/images/jquery.jpg'),
	('Projeto calculadora', GETDATE(), '/images/csharp.jpg');