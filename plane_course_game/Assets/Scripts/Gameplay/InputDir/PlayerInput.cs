using Gameplay.Core;
using Gameplay.PlayerDir;
using UnityEngine;

namespace Gameplay.InputDir
{
    public class PlayerInput : IPlayerInput, IUpdatable
    {
        #region Fields

        private PlayerPresenter _presenter;

        #endregion

        #region Methods

        public PlayerInput(PlayerPresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnPlayerDisabled += OnPlayerDisabled;
        }

        private void OnPlayerDisabled()
        {
            _presenter.OnPlayerDisabled -= OnPlayerDisabled;
            _presenter = null;
        }

        public void MoveHorizontal(float force)
        {
            _presenter?.MoveHorizontal(force);
        }

        public void MoveVertical(float force)
        {
            _presenter?.MoveVertical(force);
        }

        public void Fire()
        {
            _presenter?.Fire();
        }

        #endregion

        public void Update()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                MoveHorizontal(Input.GetAxisRaw("Horizontal"));
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                MoveVertical(Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Fire();
            }
        }
    }
}