using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Lütfen Şifreyi Boş Bırakmayın");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("En Az 6 Karakter Şifre Giriniz");
        }
    }
}
