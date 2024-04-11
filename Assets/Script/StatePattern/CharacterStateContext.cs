
public class CharacterStateContext
{
    public CharacterState CurrentState
    {
        get; set;
    }

    private readonly CharacterController characterController;


    public CharacterStateContext(CharacterController characterController)
    {
        this.characterController = characterController;
    }

    //���� ���� ������Ʈ
    public void Transition()
    {
        CurrentState.Handle(characterController);
    }

    //���� ��ȯ
    public void Transition(CharacterState state, params object[] datas)
    {
        CurrentState = state;
        CurrentState.Handle(characterController, datas);
    }
}
