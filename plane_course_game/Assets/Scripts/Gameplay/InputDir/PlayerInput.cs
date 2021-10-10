using Gameplay.Core;
using UnityEngine;

namespace Gameplay.InputDir
{
    public class PlayerInput : IPlayerInput, IUpdatable
    {
        #region Fields

     //   private CharacterPresenter _presenter;

        #endregion

        #region Methods

       // public PlayerInput(CharacterPresenter presenter)
       // {
      //      _presenter = presenter;
      ///      _presenter.OnViewDestroyed += OnViewDestroyed;
      //  }

        private void OnViewDestroyed()
        {
      //      _presenter = null;
        }

       // public void SetPresenter(CharacterPresenter presenter)
      //  {
      //  }

        public void AttackRight()
        {
         //   _presenter?.OnAttackRight();
        }

        public void MoveHorizontal(float force)
        {
            //_presenter?.OnMoveHorizontal(force);
        }

        public void MoveVertical(float force)
        {
           // _presenter?.OnMoveVertical(force);
        }

        #endregion

        public void Update()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                MoveHorizontal(Input.GetAxisRaw("Horizontal"));
            }

            if (Input.GetAxis("Vertical") == 0)
            {
               // _presenter?.StopMoving();
            }
            else
            {
                MoveVertical(Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetButtonDown("Fire1"))
            {
                AttackRight();
            }
        }
    }
}