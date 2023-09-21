using Com.Airbnb.Lottie;

namespace Lottie.Maui.Platforms.Android
{
    public static class AnimationViewExtensions
    {
        public static void TrySetAnimation(this LottieAnimationView lottieAnimationView, AnimationView animationView)
        {
            ArgumentNullException.ThrowIfNull(lottieAnimationView);

            ArgumentNullException.ThrowIfNull(animationView);

            switch (animationView.AnimationSource)
            {
                case AnimationSource.AssetOrBundle:
                    lottieAnimationView.TrySetAnimation(animationView, animationView.Animation);
                    break;
                case AnimationSource.Url:
                    if (animationView.Animation is string stringAnimation)
                        lottieAnimationView.SetAnimationFromUrl(stringAnimation);
                    break;
                case AnimationSource.Json:
                    if (animationView.Animation is string jsonAnimation)
                        lottieAnimationView.SetAnimationFromJson(jsonAnimation);
                    break;
                case AnimationSource.Stream:
                    lottieAnimationView.TrySetAnimation(animationView, animationView.Animation);
                    break;
                case AnimationSource.EmbeddedResource:
                    lottieAnimationView.TrySetAnimation(animationView, animationView.GetStreamFromAssembly());
                    break;
                default:
                    break;
            }
        }

        public static void TrySetAnimation(this LottieAnimationView lottieAnimationView, AnimationView animationView, object animation)
        {
            ArgumentNullException.ThrowIfNull(lottieAnimationView);

            ArgumentNullException.ThrowIfNull(animationView);

            switch (animation)
            {
                case int intAnimation:
                    lottieAnimationView.SetAnimation(intAnimation);
                    break;
                case string stringAnimation:

                    //TODO: check if json
                    //animationView.SetAnimationFromJson(stringAnimation);
                    //TODO: check if url
                    //animationView.SetAnimationFromUrl(stringAnimation);

                    lottieAnimationView.SetAnimation(stringAnimation);
                    break;
                case Stream streamAnimation:
                    lottieAnimationView.SetAnimation(streamAnimation, null);
                    break;
                case null:
                    lottieAnimationView.ClearAnimation();
                    break;
                default:
                    break;
            }
        }

        public static void ConfigureRepeat(this LottieAnimationView lottieAnimationView, RepeatMode repeatMode, int repeatCount)
        {
            ArgumentNullException.ThrowIfNull(lottieAnimationView);

            lottieAnimationView.RepeatCount = repeatCount;

            switch (repeatMode)
            {
                case RepeatMode.Infinite:
                    {
                        lottieAnimationView.RepeatCount = int.MaxValue;
                        lottieAnimationView.RepeatMode = LottieDrawable.Infinite;
                        break;
                    }
                case RepeatMode.Restart:
                    lottieAnimationView.RepeatMode = LottieDrawable.Restart;
                    break;
                case RepeatMode.Reverse:
                    lottieAnimationView.RepeatMode = LottieDrawable.Reverse;
                    break;
            }
        }
    }
}
