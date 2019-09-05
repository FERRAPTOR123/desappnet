namespace ControlBancario.Clases {
    public class CuentaDeCheques:CuentaBancaria {
        private double sobregiro;
        public CuentaDeCheques(double saldo, double sobregiro) 
          : base(saldo)
        {
            this.sobregiro = sobregiro;
        }

         public override bool Retira(double cantidad) {
            if(cantidad>saldo) {
                double requiere = cantidad - saldo;
                if(sobregiro < requiere) {
                    return false;        
                }
                else {
                    saldo=0;
                    sobregiro-=requiere;
                }
            }
            else {
                saldo-=cantidad;
                return true;
            }
            return true;
        }

    }
}