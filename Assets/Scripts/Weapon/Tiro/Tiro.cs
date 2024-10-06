public class Tiro : Weapon {
    public override int municaoAtual { get; set; }
    public override void Disparo() {
        if (municaoAtual <= 0) {
            return;
        }
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        Logar("TIRO", municaoAtual);
        municaoAtual--;
    }
}
