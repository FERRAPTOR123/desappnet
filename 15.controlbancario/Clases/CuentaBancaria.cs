namespace ControlBancario.Clases
{
    public class CuentaBancaria {
         
        protected double saldo; // permite acceso a las clases q hereden

        public CuentaBancaria() {}
        public CuentaBancaria(double saldo) {
            this.saldo = saldo;
        }
             
        public double Saldo
        {
            get { return saldo; }
        }

        public void Deposita(double cantidad) {
            if(cantidad>0) 
                saldo+=cantidad;
        }
        
        public virtual bool Retira(double cantidad)  // permite sobrecarga
        {
            if(saldo>=cantidad) {
                saldo-=cantidad;
                return true;
            } else return false;
        }
        
        

    }


}
