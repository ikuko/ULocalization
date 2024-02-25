using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization.Udon {
	internal partial class UdonLocalization {
		// UnityEngineAINavMeshAgent.__set_name__SystemString__SystemVoid
		public void __c1b5cd9fce156c5b4e42ad2d39dbbe82() {
			((global::UnityEngine.AI.NavMeshAgent)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAINavMeshAgent.__set_name__SystemString__SystemVoid
		public void __f4acb753fd042fb8bf713ff5e90fb0d4() {
			((global::UnityEngine.AI.NavMeshAgent)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAINavMeshAgent.__CompleteOffMeshLink__SystemVoid
		public void __0bf0b1b18ad0f865ed8825d48c851014() {
			((global::UnityEngine.AI.NavMeshAgent)listenerTarget[listenerIdx]).CompleteOffMeshLink();
		}

		// UnityEngineAINavMeshAgent.__ResetPath__SystemVoid
		public void __88bcd41a9471a1487a6e7e84d9f66f01() {
			((global::UnityEngine.AI.NavMeshAgent)listenerTarget[listenerIdx]).ResetPath();
		}

		// UnityEngineAINavMeshObstacle.__set_name__SystemString__SystemVoid
		public void __e79877f710b3a03725317ffaf2ed1f0d() {
			((global::UnityEngine.AI.NavMeshObstacle)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAINavMeshObstacle.__set_name__SystemString__SystemVoid
		public void __12813a3f6b7d8188afe8185745f7d4a5() {
			((global::UnityEngine.AI.NavMeshObstacle)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAIOffMeshLink.__set_name__SystemString__SystemVoid
		public void __dd9b0bb39e6b8514e3f305f216f9b1e9() {
			((global::UnityEngine.AI.OffMeshLink)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAIOffMeshLink.__set_name__SystemString__SystemVoid
		public void __f3708361118bb8817d31965e761fdc6d() {
			((global::UnityEngine.AI.OffMeshLink)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAIOffMeshLink.__UpdatePositions__SystemVoid
		public void __e254fa991fcbe7c78e48b59c5c58fcb0() {
			((global::UnityEngine.AI.OffMeshLink)listenerTarget[listenerIdx]).UpdatePositions();
		}

		// UnityEngineAnimator.__set_name__SystemString__SystemVoid
		public void __b4d7b5af0c568c9d2e737fca344cbdce() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimator.__set_name__SystemString__SystemVoid
		public void __e4ac5d1ecb4a2f3f8da1dddc754873a5() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAnimator.__SetTrigger__SystemString__SystemVoid.0
		public void __d4ce819fda6119469efa9dbc8a99fe81() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).SetTrigger(
				listenerString
			);
		}

		// UnityEngineAnimator.__SetTrigger__SystemString__SystemVoid.1
		public void __82ca72ffd304157d6a12e8531cb9e33c() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).SetTrigger(
				(global::System.String)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineAnimator.__ResetTrigger__SystemString__SystemVoid.0
		public void __54bb8289aaed862aeafd8962bdfbf99d() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).ResetTrigger(
				listenerString
			);
		}

		// UnityEngineAnimator.__ResetTrigger__SystemString__SystemVoid.1
		public void __99376009fd10b0bfbc51663ec999765d() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).ResetTrigger(
				(global::System.String)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineAnimator.__InterruptMatchTarget__SystemVoid
		public void __60404225c92660eda5697f68eb0ef045() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).InterruptMatchTarget();
		}

		// UnityEngineAnimator.__WriteDefaultValues__SystemVoid
		public void __1f8e76a399052f203c71c94239ee33a7() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).WriteDefaultValues();
		}

		// UnityEngineAnimator.__PlayInFixedTime__SystemString__SystemVoid.0
		public void __377706ea2c38944400208ff28ada7357() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).PlayInFixedTime(
				listenerString
			);
		}

		// UnityEngineAnimator.__PlayInFixedTime__SystemString__SystemVoid.1
		public void __c2c0eb963b215ee71ecb33c332fe9e9b() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).PlayInFixedTime(
				(global::System.String)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineAnimator.__Play__SystemString__SystemVoid.0
		public void __f0aa2f0fc3a3bb821bf18cedf7a3f300() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).Play(
				listenerString
			);
		}

		// UnityEngineAnimator.__Play__SystemString__SystemVoid.1
		public void __a497f1d72e842b2b7ed13632befdec44() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).Play(
				(global::System.String)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineAnimator.__StartPlayback__SystemVoid
		public void __3cedb8b15eadf9a7cb84b7560a535e60() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).StartPlayback();
		}

		// UnityEngineAnimator.__StopPlayback__SystemVoid
		public void __42da87b2564e15eb74e28cb79d27e835() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).StopPlayback();
		}

		// UnityEngineAnimator.__StopRecording__SystemVoid
		public void __3d4492db6b601cd569714c9955c3eb9f() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).StopRecording();
		}

		// UnityEngineAnimator.__Rebind__SystemVoid
		public void __4408c52cd1eba0e4f37b2e394d80a9a3() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).Rebind();
		}

		// UnityEngineAnimator.__ApplyBuiltinRootMotion__SystemVoid
		public void __e3b249a9dd816770ab9e96074c1ae5a8() {
			((global::UnityEngine.Animator)listenerTarget[listenerIdx]).ApplyBuiltinRootMotion();
		}

		// UnityEngineAnimationsAimConstraint.__set_name__SystemString__SystemVoid
		public void __f92ff533f1bcaf16ba9c9e0d51f2769a() {
			((global::UnityEngine.Animations.AimConstraint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimationsAimConstraint.__set_name__SystemString__SystemVoid
		public void __9abc3d8a7736cf69cc5abd6e0945ce6b() {
			((global::UnityEngine.Animations.AimConstraint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAnimationsPositionConstraint.__set_name__SystemString__SystemVoid
		public void __36f02faaabc754724a5fcd14626dab70() {
			((global::UnityEngine.Animations.PositionConstraint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimationsPositionConstraint.__set_name__SystemString__SystemVoid
		public void __24805d096c000a269c39bc9d8812c503() {
			((global::UnityEngine.Animations.PositionConstraint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAnimationsRotationConstraint.__set_name__SystemString__SystemVoid
		public void __adf6b083f76149797d3b796f8e82ac17() {
			((global::UnityEngine.Animations.RotationConstraint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimationsRotationConstraint.__set_name__SystemString__SystemVoid
		public void __995a1da9f10165c479a580d3a0ae586b() {
			((global::UnityEngine.Animations.RotationConstraint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAnimationsScaleConstraint.__set_name__SystemString__SystemVoid
		public void __d972cf319d4b1076e02f6edddb910c0d() {
			((global::UnityEngine.Animations.ScaleConstraint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimationsScaleConstraint.__set_name__SystemString__SystemVoid
		public void __3661dc6578fe77afbe325d627fc1b15f() {
			((global::UnityEngine.Animations.ScaleConstraint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAnimationsLookAtConstraint.__set_name__SystemString__SystemVoid
		public void __38259543cbdf64ca1fb31e1e5d52d613() {
			((global::UnityEngine.Animations.LookAtConstraint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimationsLookAtConstraint.__set_name__SystemString__SystemVoid
		public void __4969cf69d9537369b7ec6824966cc549() {
			((global::UnityEngine.Animations.LookAtConstraint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAnimationsParentConstraint.__set_name__SystemString__SystemVoid
		public void __6c4015db18a1afe1d63567573954e95c() {
			((global::UnityEngine.Animations.ParentConstraint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAnimationsParentConstraint.__set_name__SystemString__SystemVoid
		public void __39c3b2c2a965505730fcce6a853752e9() {
			((global::UnityEngine.Animations.ParentConstraint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioSource.__set_clip__UnityEngineAudioClip__SystemVoid
		public void __6c8a6ecb4c3242b89fdf6f6549c70d66() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).clip
				= (global::UnityEngine.AudioClip)listenerAsset;
		}

		// UnityEngineAudioSource.__set_clip__UnityEngineAudioClip__SystemVoid
		public void __20236a07f5e561b3ef2c320e402c7635() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).clip
				= (global::UnityEngine.AudioClip)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioSource.__set_name__SystemString__SystemVoid
		public void __2c6b692c65d509771d7e015d43052c16() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioSource.__set_name__SystemString__SystemVoid
		public void __1499b8b6de01b154889c3fb3ed0063f3() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioSource.__Play__SystemVoid
		public void __70a743be5e906afbcdaf61eef0000416() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).Play();
		}

		// UnityEngineAudioSource.__PlayOneShot__UnityEngineAudioClip__SystemVoid.0
		public void __22c67020bf9fc2a0df2f10a1aff4bfc5() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).PlayOneShot(
				(global::UnityEngine.AudioClip)listenerAsset
			);
		}

		// UnityEngineAudioSource.__PlayOneShot__UnityEngineAudioClip__SystemVoid.1
		public void __10b380eca75cfd82164950638b68f0b5() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).PlayOneShot(
				(global::UnityEngine.AudioClip)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineAudioSource.__Stop__SystemVoid
		public void __c2695b9c9157932557fdf9f5a0fe112f() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).Stop();
		}

		// UnityEngineAudioSource.__Pause__SystemVoid
		public void __9382364c327f843712d6c08140085e59() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).Pause();
		}

		// UnityEngineAudioSource.__UnPause__SystemVoid
		public void __86716019fe60cd910d71f77fc9e8bb4e() {
			((global::UnityEngine.AudioSource)listenerTarget[listenerIdx]).UnPause();
		}

		// UnityEngineAudioLowPassFilter.__set_name__SystemString__SystemVoid
		public void __4712b4b6fa2a1388f7e414b1fb1e9baf() {
			((global::UnityEngine.AudioLowPassFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioLowPassFilter.__set_name__SystemString__SystemVoid
		public void __e09a8f662f118febbfbe95a8b7b0101c() {
			((global::UnityEngine.AudioLowPassFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioHighPassFilter.__set_name__SystemString__SystemVoid
		public void __f937a8667560dc40919efd70d7e334b4() {
			((global::UnityEngine.AudioHighPassFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioHighPassFilter.__set_name__SystemString__SystemVoid
		public void __1ee7f0ee5a8d16074a1e9ad29d54aac0() {
			((global::UnityEngine.AudioHighPassFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioReverbFilter.__set_name__SystemString__SystemVoid
		public void __7383d1ffd4ccf9eb72275ddc75d16cc8() {
			((global::UnityEngine.AudioReverbFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioReverbFilter.__set_name__SystemString__SystemVoid
		public void __1b3dc9d518e03f1f146687a9dab80d41() {
			((global::UnityEngine.AudioReverbFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioReverbZone.__set_name__SystemString__SystemVoid
		public void __58cc0471221cd447cb2220b064f0618c() {
			((global::UnityEngine.AudioReverbZone)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioReverbZone.__set_name__SystemString__SystemVoid
		public void __2a7c01bb6ecd403776e9730ed3886651() {
			((global::UnityEngine.AudioReverbZone)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioDistortionFilter.__set_name__SystemString__SystemVoid
		public void __e26cc5ee360ea2233683dabe302359c5() {
			((global::UnityEngine.AudioDistortionFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioDistortionFilter.__set_name__SystemString__SystemVoid
		public void __ee279aa398cc54e69079834abbd38bab() {
			((global::UnityEngine.AudioDistortionFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioEchoFilter.__set_name__SystemString__SystemVoid
		public void __e1b8714150475319443e94d05f3af1b6() {
			((global::UnityEngine.AudioEchoFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioEchoFilter.__set_name__SystemString__SystemVoid
		public void __f57f7a604035f5853c8a14114db88967() {
			((global::UnityEngine.AudioEchoFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAudioChorusFilter.__set_name__SystemString__SystemVoid
		public void __7a38fa0a3a40b4af1f77db8bc3c5769c() {
			((global::UnityEngine.AudioChorusFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAudioChorusFilter.__set_name__SystemString__SystemVoid
		public void __59b98a58f0554084819119076ef5db1d() {
			((global::UnityEngine.AudioChorusFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCamera.__set_name__SystemString__SystemVoid
		public void __6a4f4feb445d83278c0cf4ed5a22dbf1() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCamera.__set_name__SystemString__SystemVoid
		public void __74328137344e873badcce19ca0a6a329() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCamera.__Reset__SystemVoid
		public void __ab67cc9183c1b1256433e84c4c7b88c8() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).Reset();
		}

		// UnityEngineCamera.__ResetTransparencySortSettings__SystemVoid
		public void __a95ffb8c4a3d39a6adadb46497422c66() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetTransparencySortSettings();
		}

		// UnityEngineCamera.__ResetAspect__SystemVoid
		public void __6292f5365f459fd15449499f880bae56() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetAspect();
		}

		// UnityEngineCamera.__ResetCullingMatrix__SystemVoid
		public void __d9451e6937a424c2ad149013b329a4ff() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetCullingMatrix();
		}

		// UnityEngineCamera.__ResetReplacementShader__SystemVoid
		public void __ab68900e4cdddd9f826fbbc3e7ab5115() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetReplacementShader();
		}

		// UnityEngineCamera.__ResetWorldToCameraMatrix__SystemVoid
		public void __6b8c3024cd7060d73b553804948ffc83() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetWorldToCameraMatrix();
		}

		// UnityEngineCamera.__ResetProjectionMatrix__SystemVoid
		public void __74a725d5b5ddd3270c009326b3f636f1() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetProjectionMatrix();
		}

		// UnityEngineCamera.__ResetStereoProjectionMatrices__SystemVoid
		public void __d7f9e08f9d2c4f6241178b6f3edc34c4() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetStereoProjectionMatrices();
		}

		// UnityEngineCamera.__ResetStereoViewMatrices__SystemVoid
		public void __80ff86893c5a233be8bdce5d4f4a8093() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).ResetStereoViewMatrices();
		}

		// UnityEngineCamera.__Render__SystemVoid
		public void __de88b212e05de6c7a83c536f2b86f24b() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).Render();
		}

		// UnityEngineCamera.__RenderDontRestore__SystemVoid
		public void __26b9935948a74d4242b6d3f725aeb30e() {
			((global::UnityEngine.Camera)listenerTarget[listenerIdx]).RenderDontRestore();
		}

		// UnityEngineReflectionProbe.__set_bakedTexture__UnityEngineTexture__SystemVoid
		public void __f7b250cf95fc628df26acfb4d928fcdd() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).bakedTexture
				= (global::UnityEngine.Texture)listenerAsset;
		}

		// UnityEngineReflectionProbe.__set_bakedTexture__UnityEngineTexture__SystemVoid
		public void __6bc303cc3c4b2acb76c3bc5f5a40821b() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).bakedTexture
				= (global::UnityEngine.Texture)listenerArgument[listenerIdx];
		}

		// UnityEngineReflectionProbe.__set_customBakedTexture__UnityEngineTexture__SystemVoid
		public void __8f2e0415aaadb67e11de029b466095bc() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).customBakedTexture
				= (global::UnityEngine.Texture)listenerAsset;
		}

		// UnityEngineReflectionProbe.__set_customBakedTexture__UnityEngineTexture__SystemVoid
		public void __770bf0e14f1610f6ae4be8eddb6fe98c() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).customBakedTexture
				= (global::UnityEngine.Texture)listenerArgument[listenerIdx];
		}

		// UnityEngineReflectionProbe.__set_name__SystemString__SystemVoid
		public void __10da086d7e2899609e0565a9695d4a9e() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineReflectionProbe.__set_name__SystemString__SystemVoid
		public void __1350b62ded2d9f6b634854cddcc920c1() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineReflectionProbe.__Reset__SystemVoid
		public void __58ff72e6c3786bd60f3ba55b0db7ec36() {
			((global::UnityEngine.ReflectionProbe)listenerTarget[listenerIdx]).Reset();
		}

		// UnityEngineBillboardRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __25c9bdd2a1ddcd726223589ba16eae25() {
			((global::UnityEngine.BillboardRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineBillboardRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __0148d81bc05ff9c8407ffb7ef6a0399e() {
			((global::UnityEngine.BillboardRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineBillboardRenderer.__set_name__SystemString__SystemVoid
		public void __038d03caaad19bff16d0d65c36c4898e() {
			((global::UnityEngine.BillboardRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineBillboardRenderer.__set_name__SystemString__SystemVoid
		public void __522be33f858d30ff27f6e7040fbaeeac() {
			((global::UnityEngine.BillboardRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineBillboardRenderer.__ResetBounds__SystemVoid
		public void __863dd244d26f51c99444721d20876e03() {
			((global::UnityEngine.BillboardRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineBillboardRenderer.__ResetLocalBounds__SystemVoid
		public void __3f60bd6dad89031634ff9203c4cdd5c5() {
			((global::UnityEngine.BillboardRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __ede3f35f6845123d94200b16b336cd01() {
			((global::UnityEngine.Renderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __596628520c7ccbe3c6d2d1064c77eb51() {
			((global::UnityEngine.Renderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRenderer.__set_name__SystemString__SystemVoid
		public void __d55b412645023ee8a47f72579509837e() {
			((global::UnityEngine.Renderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineRenderer.__set_name__SystemString__SystemVoid
		public void __e0e26a8352d5fd556c31fd723baf0975() {
			((global::UnityEngine.Renderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRenderer.__ResetBounds__SystemVoid
		public void __fd623b738e218f724d2e28609489d173() {
			((global::UnityEngine.Renderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineRenderer.__ResetLocalBounds__SystemVoid
		public void __8405bf6f67e83f4f182b83eda0376258() {
			((global::UnityEngine.Renderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineTrailRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __b7485e68aa16a7d1f7e2fdec1e679ae0() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineTrailRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __2e13ae827d6f056433f0469fa3d98112() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineTrailRenderer.__set_name__SystemString__SystemVoid
		public void __766b02ef2b5b9b3c29d1f706762665e5() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineTrailRenderer.__set_name__SystemString__SystemVoid
		public void __c5abc7761067aefba7112100f4b10418() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineTrailRenderer.__Clear__SystemVoid
		public void __38eb2d5350424863230bc35b7c84287e() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).Clear();
		}

		// UnityEngineTrailRenderer.__ResetBounds__SystemVoid
		public void __f643f45c8ff1a8cf3aee2f375107d14c() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineTrailRenderer.__ResetLocalBounds__SystemVoid
		public void __866e54cd477439e390f61fd874f927fe() {
			((global::UnityEngine.TrailRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineLineRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __541297bf7df87482481ddeeac6fb5a90() {
			((global::UnityEngine.LineRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineLineRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __64cb10cbb9921a51a291fcca9109c4df() {
			((global::UnityEngine.LineRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineLineRenderer.__set_name__SystemString__SystemVoid
		public void __93401f8d5d6565270db48becad121910() {
			((global::UnityEngine.LineRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineLineRenderer.__set_name__SystemString__SystemVoid
		public void __395dbcc57af9fd2cd7cac7db9d5ddc25() {
			((global::UnityEngine.LineRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineLineRenderer.__ResetBounds__SystemVoid
		public void __e7e88535e83549679f4c7ed12fc0bb50() {
			((global::UnityEngine.LineRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineLineRenderer.__ResetLocalBounds__SystemVoid
		public void __2158ffb6b1789dca25f6a2b5bacd2cc4() {
			((global::UnityEngine.LineRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineOcclusionPortal.__set_name__SystemString__SystemVoid
		public void __7d32e43fa1be3bd0397fcdc02b20f3bc() {
			((global::UnityEngine.OcclusionPortal)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineOcclusionPortal.__set_name__SystemString__SystemVoid
		public void __af8333eba305251366aada9c9c9a7e7b() {
			((global::UnityEngine.OcclusionPortal)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineLight.__set_cookie__UnityEngineTexture__SystemVoid
		public void __0300c54d9893d593d5f2f9a38374a605() {
			((global::UnityEngine.Light)listenerTarget[listenerIdx]).cookie
				= (global::UnityEngine.Texture)listenerAsset;
		}

		// UnityEngineLight.__set_cookie__UnityEngineTexture__SystemVoid
		public void __0f92ab37de7cb244521541f5c0b270fa() {
			((global::UnityEngine.Light)listenerTarget[listenerIdx]).cookie
				= (global::UnityEngine.Texture)listenerArgument[listenerIdx];
		}

		// UnityEngineLight.__set_name__SystemString__SystemVoid
		public void __a4f577be1dc30463657956ac06df61a2() {
			((global::UnityEngine.Light)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineLight.__set_name__SystemString__SystemVoid
		public void __8801446f956ebbdbca7af12065400b77() {
			((global::UnityEngine.Light)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineLight.__Reset__SystemVoid
		public void __669ca988fb9c9bd11b6d34c7b7a32984() {
			((global::UnityEngine.Light)listenerTarget[listenerIdx]).Reset();
		}

		// UnityEngineMeshFilter.__set_name__SystemString__SystemVoid
		public void __cf5b526843f6bb87d84fa40b0d965347() {
			((global::UnityEngine.MeshFilter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineMeshFilter.__set_name__SystemString__SystemVoid
		public void __8ff812175088d0a50ac553ca931e5ac4() {
			((global::UnityEngine.MeshFilter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSkinnedMeshRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __1c9d376f49106232224843a101d17e9d() {
			((global::UnityEngine.SkinnedMeshRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineSkinnedMeshRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __aa37d87ca1ac42a7e83ab45791e126a5() {
			((global::UnityEngine.SkinnedMeshRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSkinnedMeshRenderer.__set_name__SystemString__SystemVoid
		public void __115d9b389942685a8fc54086ffebe014() {
			((global::UnityEngine.SkinnedMeshRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineSkinnedMeshRenderer.__set_name__SystemString__SystemVoid
		public void __8d65b8a1bd639243d49dfeb673e1c8b1() {
			((global::UnityEngine.SkinnedMeshRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSkinnedMeshRenderer.__ResetBounds__SystemVoid
		public void __01ab5d8d71da2b9f1c2121bb4b6fd37c() {
			((global::UnityEngine.SkinnedMeshRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineSkinnedMeshRenderer.__ResetLocalBounds__SystemVoid
		public void __89a72429878fcc11c1c383c45da73756() {
			((global::UnityEngine.SkinnedMeshRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineMeshRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __d150d0a9aa4a0d45b30efca3d5b3407b() {
			((global::UnityEngine.MeshRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineMeshRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __b44185c9b9d9b5e5d6a9791a72b172c4() {
			((global::UnityEngine.MeshRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineMeshRenderer.__set_name__SystemString__SystemVoid
		public void __109ea2b10a3aa9ef84a9dc58347f24dd() {
			((global::UnityEngine.MeshRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineMeshRenderer.__set_name__SystemString__SystemVoid
		public void __79b66f320bda9908bd92e7b30ece0eeb() {
			((global::UnityEngine.MeshRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineMeshRenderer.__ResetBounds__SystemVoid
		public void __c7bea9ecb7e0371a5023e43bfcd15c1d() {
			((global::UnityEngine.MeshRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineMeshRenderer.__ResetLocalBounds__SystemVoid
		public void __924b0c5de186e67692a2f70e71a68723() {
			((global::UnityEngine.MeshRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineRectTransform.__set_name__SystemString__SystemVoid
		public void __02d06f3f8f48ece61b243cc1626897fc() {
			((global::UnityEngine.RectTransform)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineRectTransform.__set_name__SystemString__SystemVoid
		public void __c8e552281c4b44de324446ccde1ba0c6() {
			((global::UnityEngine.RectTransform)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRectTransform.__ForceUpdateRectTransforms__SystemVoid
		public void __3f17e16fc9da6b5d1272af943f16a72f() {
			((global::UnityEngine.RectTransform)listenerTarget[listenerIdx]).ForceUpdateRectTransforms();
		}

		// UnityEngineRectTransform.__DetachChildren__SystemVoid
		public void __d9d90b3db4f46944a94896a2c783d928() {
			((global::UnityEngine.RectTransform)listenerTarget[listenerIdx]).DetachChildren();
		}

		// UnityEngineRectTransform.__SetAsFirstSibling__SystemVoid
		public void __1ed964458bd42e6a9ae492e8d253d333() {
			((global::UnityEngine.RectTransform)listenerTarget[listenerIdx]).SetAsFirstSibling();
		}

		// UnityEngineRectTransform.__SetAsLastSibling__SystemVoid
		public void __f637c4b11c2200702a812ab477193847() {
			((global::UnityEngine.RectTransform)listenerTarget[listenerIdx]).SetAsLastSibling();
		}

		// UnityEngineTransform.__set_name__SystemString__SystemVoid
		public void __17b1433ae96753e048eb89a76f2ebd99() {
			((global::UnityEngine.Transform)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineTransform.__set_name__SystemString__SystemVoid
		public void __33674239a5d83d0d0b0a3905e1d21269() {
			((global::UnityEngine.Transform)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineTransform.__DetachChildren__SystemVoid
		public void __613cb2d842afe9c98d63abf0e5f75a67() {
			((global::UnityEngine.Transform)listenerTarget[listenerIdx]).DetachChildren();
		}

		// UnityEngineTransform.__SetAsFirstSibling__SystemVoid
		public void __2c9c60ee590ee1fb47e8b19f482b55a0() {
			((global::UnityEngine.Transform)listenerTarget[listenerIdx]).SetAsFirstSibling();
		}

		// UnityEngineTransform.__SetAsLastSibling__SystemVoid
		public void __798526e6fe0c9b33706c6b46a4833d05() {
			((global::UnityEngine.Transform)listenerTarget[listenerIdx]).SetAsLastSibling();
		}

		// UnityEngineSpriteRenderer.__set_sprite__UnityEngineSprite__SystemVoid
		public void __65655ec0e961d87b3fa1355dce4b1ed1() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).sprite
				= (global::UnityEngine.Sprite)listenerAsset;
		}

		// UnityEngineSpriteRenderer.__set_sprite__UnityEngineSprite__SystemVoid
		public void __d9b0156e65b30f747b450c8a1465bccd() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).sprite
				= (global::UnityEngine.Sprite)listenerArgument[listenerIdx];
		}

		// UnityEngineSpriteRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __0be599ef715f88a9be572484664ce585() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineSpriteRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __447ceac87bce838d84bb521fcd1459fa() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSpriteRenderer.__set_name__SystemString__SystemVoid
		public void __bf85d392908160c48ea82f864a510088() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineSpriteRenderer.__set_name__SystemString__SystemVoid
		public void __77d298a1ccce90d8b4d261f816d356d5() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSpriteRenderer.__ResetBounds__SystemVoid
		public void __325c401dfbdbfe6277b8400f95464aa4() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineSpriteRenderer.__ResetLocalBounds__SystemVoid
		public void __33ccdb268656b3d93920023f72e41eef() {
			((global::UnityEngine.SpriteRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEnginePlayablesPlayableDirector.__set_name__SystemString__SystemVoid
		public void __653db5b877cf1e2373c016ee703ce353() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEnginePlayablesPlayableDirector.__set_name__SystemString__SystemVoid
		public void __92404f712d4c306501ebfa0355b33c40() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEnginePlayablesPlayableDirector.__DeferredEvaluate__SystemVoid
		public void __7cd547d99af9b64a617c54112ef832f8() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).DeferredEvaluate();
		}

		// UnityEnginePlayablesPlayableDirector.__Evaluate__SystemVoid
		public void __326541e9ab0e7594004eb4af86aec9ed() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).Evaluate();
		}

		// UnityEnginePlayablesPlayableDirector.__Play__SystemVoid
		public void __506881abe79a154c6a517c85cc84de1e() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).Play();
		}

		// UnityEnginePlayablesPlayableDirector.__Stop__SystemVoid
		public void __a048e2f5d4a91c60da8bb67107087558() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).Stop();
		}

		// UnityEnginePlayablesPlayableDirector.__Pause__SystemVoid
		public void __b1f76fe076377a83a3fcdbc1011f285c() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).Pause();
		}

		// UnityEnginePlayablesPlayableDirector.__Resume__SystemVoid
		public void __ea98384d5c84102065cd45f5e367e428() {
			((global::UnityEngine.Playables.PlayableDirector)listenerTarget[listenerIdx]).Resume();
		}

		// UnityEngineParticleSystem.__set_name__SystemString__SystemVoid
		public void __b4b5be5925d446f8157580b5dca23230() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineParticleSystem.__set_name__SystemString__SystemVoid
		public void __f168b17d35442c3165046e98984ecc01() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineParticleSystem.__Play__SystemVoid
		public void __958f00114d657f44c4dc855b001d5fdf() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).Play();
		}

		// UnityEngineParticleSystem.__Pause__SystemVoid
		public void __a549081f4340ea8ef5c89e6ab4037c1c() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).Pause();
		}

		// UnityEngineParticleSystem.__Stop__SystemVoid
		public void __d539c2eb6f0207952a82244aea3f8a59() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).Stop();
		}

		// UnityEngineParticleSystem.__Clear__SystemVoid
		public void __835ccd655866cc40d51eec38b49cb1ea() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).Clear();
		}

		// UnityEngineParticleSystem.__AllocateAxisOfRotationAttribute__SystemVoid
		public void __a278b316fd482edf429c0525267f6707() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).AllocateAxisOfRotationAttribute();
		}

		// UnityEngineParticleSystem.__AllocateMeshIndexAttribute__SystemVoid
		public void __8e3b722caf2d26974aa8e35a80dfb09c() {
			((global::UnityEngine.ParticleSystem)listenerTarget[listenerIdx]).AllocateMeshIndexAttribute();
		}

		// UnityEngineParticleSystemRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __b98e1c149075630e4730aa196413bc9f() {
			((global::UnityEngine.ParticleSystemRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineParticleSystemRenderer.__set_sortingLayerName__SystemString__SystemVoid
		public void __8bb39b459cf84e6c66565a79dccf4da3() {
			((global::UnityEngine.ParticleSystemRenderer)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineParticleSystemRenderer.__set_name__SystemString__SystemVoid
		public void __0844aea515e531e6a82a46cf77341f1b() {
			((global::UnityEngine.ParticleSystemRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineParticleSystemRenderer.__set_name__SystemString__SystemVoid
		public void __b28b032e2b6becb7f5996f32db0ebfe8() {
			((global::UnityEngine.ParticleSystemRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineParticleSystemRenderer.__ResetBounds__SystemVoid
		public void __1b0b16cc7daef073e95bf14ae5ffbf80() {
			((global::UnityEngine.ParticleSystemRenderer)listenerTarget[listenerIdx]).ResetBounds();
		}

		// UnityEngineParticleSystemRenderer.__ResetLocalBounds__SystemVoid
		public void __ca57ca8f2bb4383c1e3118d2f8eaaed8() {
			((global::UnityEngine.ParticleSystemRenderer)listenerTarget[listenerIdx]).ResetLocalBounds();
		}

		// UnityEngineRigidbody.__set_name__SystemString__SystemVoid
		public void __a80414a5a25c92f98ff4eeef15e8d5d7() {
			((global::UnityEngine.Rigidbody)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineRigidbody.__set_name__SystemString__SystemVoid
		public void __38e3a7ec2d41d348ef93140517880894() {
			((global::UnityEngine.Rigidbody)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRigidbody.__Sleep__SystemVoid
		public void __f13f7571a5f66eca62176063bded2df5() {
			((global::UnityEngine.Rigidbody)listenerTarget[listenerIdx]).Sleep();
		}

		// UnityEngineRigidbody.__WakeUp__SystemVoid
		public void __1cb76a96c6180d580e45d691defcdd74() {
			((global::UnityEngine.Rigidbody)listenerTarget[listenerIdx]).WakeUp();
		}

		// UnityEngineRigidbody.__ResetCenterOfMass__SystemVoid
		public void __712928655a4c89f483617e8263e21e9f() {
			((global::UnityEngine.Rigidbody)listenerTarget[listenerIdx]).ResetCenterOfMass();
		}

		// UnityEngineRigidbody.__ResetInertiaTensor__SystemVoid
		public void __5b83f37a3570f6f4aa62a6b45cb8037d() {
			((global::UnityEngine.Rigidbody)listenerTarget[listenerIdx]).ResetInertiaTensor();
		}

		// UnityEngineCollider.__set_name__SystemString__SystemVoid
		public void __888804c5a34c0ba7146ed8936d7d0caf() {
			((global::UnityEngine.Collider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCollider.__set_name__SystemString__SystemVoid
		public void __c6d9c8b9037157162b964ac90df1abee() {
			((global::UnityEngine.Collider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCharacterController.__set_name__SystemString__SystemVoid
		public void __3ef0ccc51a490eb8e55f0afc9887c6bb() {
			((global::UnityEngine.CharacterController)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCharacterController.__set_name__SystemString__SystemVoid
		public void __185a1824ae195f9640508346f5d8a40a() {
			((global::UnityEngine.CharacterController)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineMeshCollider.__set_name__SystemString__SystemVoid
		public void __1dc714399339fe80a85a1d92aee6ab5e() {
			((global::UnityEngine.MeshCollider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineMeshCollider.__set_name__SystemString__SystemVoid
		public void __8a2d981c655da35ee6dbaf41fbaae189() {
			((global::UnityEngine.MeshCollider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCapsuleCollider.__set_name__SystemString__SystemVoid
		public void __c3ae77b9b6d925219934be77fa2f3946() {
			((global::UnityEngine.CapsuleCollider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCapsuleCollider.__set_name__SystemString__SystemVoid
		public void __15837574caed0c1f6c8337f477ba561d() {
			((global::UnityEngine.CapsuleCollider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineBoxCollider.__set_name__SystemString__SystemVoid
		public void __f39d2464df6b7afcbf76c8894ac88e90() {
			((global::UnityEngine.BoxCollider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineBoxCollider.__set_name__SystemString__SystemVoid
		public void __c59861b2112d9a56940b637615f1bb8e() {
			((global::UnityEngine.BoxCollider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSphereCollider.__set_name__SystemString__SystemVoid
		public void __d75be6b8998ad54a5bccbdae5917aea2() {
			((global::UnityEngine.SphereCollider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineSphereCollider.__set_name__SystemString__SystemVoid
		public void __4cc9d049c65958bc98c3b96ff763240d() {
			((global::UnityEngine.SphereCollider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineConstantForce.__set_name__SystemString__SystemVoid
		public void __8b583273bf357d7a9a10cebe01010cae() {
			((global::UnityEngine.ConstantForce)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineConstantForce.__set_name__SystemString__SystemVoid
		public void __e1af3a8568760bf472075415b37ffbfa() {
			((global::UnityEngine.ConstantForce)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineJoint.__set_name__SystemString__SystemVoid
		public void __f204fd79456172f909f9bc419f065095() {
			((global::UnityEngine.Joint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineJoint.__set_name__SystemString__SystemVoid
		public void __6ee2d5b1f5ff5194469ea9ca2733b325() {
			((global::UnityEngine.Joint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineHingeJoint.__set_name__SystemString__SystemVoid
		public void __0a96177d5ea2666e6e6b715287572b38() {
			((global::UnityEngine.HingeJoint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineHingeJoint.__set_name__SystemString__SystemVoid
		public void __1e16663e0dd82776383247a9c22d52d7() {
			((global::UnityEngine.HingeJoint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSpringJoint.__set_name__SystemString__SystemVoid
		public void __757c318f1a9739036dc9dae5467e3395() {
			((global::UnityEngine.SpringJoint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineSpringJoint.__set_name__SystemString__SystemVoid
		public void __f01ca7ba00b42c9164f99c56680d3a9e() {
			((global::UnityEngine.SpringJoint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineFixedJoint.__set_name__SystemString__SystemVoid
		public void __16733b71b9076200d0af8b23217e5613() {
			((global::UnityEngine.FixedJoint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineFixedJoint.__set_name__SystemString__SystemVoid
		public void __c1b4bc4ed15355278ab0c21c24c8a5b1() {
			((global::UnityEngine.FixedJoint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineConfigurableJoint.__set_name__SystemString__SystemVoid
		public void __6f9c46b496a13f6492af5b1ecf671a7b() {
			((global::UnityEngine.ConfigurableJoint)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineConfigurableJoint.__set_name__SystemString__SystemVoid
		public void __b176291edbb02673db878366684f5881() {
			((global::UnityEngine.ConfigurableJoint)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRigidbody2D.__set_name__SystemString__SystemVoid
		public void __0c272cb7d385ce337d8116a17b575edb() {
			((global::UnityEngine.Rigidbody2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineRigidbody2D.__set_name__SystemString__SystemVoid
		public void __08291239f52ce14d2f8c5340f594fb83() {
			((global::UnityEngine.Rigidbody2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRigidbody2D.__Sleep__SystemVoid
		public void __e4cbc4f61d50d39feca587b55915bc34() {
			((global::UnityEngine.Rigidbody2D)listenerTarget[listenerIdx]).Sleep();
		}

		// UnityEngineRigidbody2D.__WakeUp__SystemVoid
		public void __f7fb72d120180c2d60b746889ecbf6f6() {
			((global::UnityEngine.Rigidbody2D)listenerTarget[listenerIdx]).WakeUp();
		}

		// UnityEngineCollider2D.__set_name__SystemString__SystemVoid
		public void __1dc0c76899e18f0483d6bb9a5afa2c24() {
			((global::UnityEngine.Collider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCollider2D.__set_name__SystemString__SystemVoid
		public void __9bdd056bf80e7af1d6fd43427c8b0d5a() {
			((global::UnityEngine.Collider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCircleCollider2D.__set_name__SystemString__SystemVoid
		public void __ab183d155a54927a76b15264770c6c1d() {
			((global::UnityEngine.CircleCollider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCircleCollider2D.__set_name__SystemString__SystemVoid
		public void __ae029dd7b41a581b2ff169d3c8ee613c() {
			((global::UnityEngine.CircleCollider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCapsuleCollider2D.__set_name__SystemString__SystemVoid
		public void __e61f1898dcc0a753dc34e3606b37ceba() {
			((global::UnityEngine.CapsuleCollider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCapsuleCollider2D.__set_name__SystemString__SystemVoid
		public void __0402ad11524c6231c17a82a50332424c() {
			((global::UnityEngine.CapsuleCollider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineEdgeCollider2D.__set_name__SystemString__SystemVoid
		public void __5d3a309f91d6b5033e513a616099bc4d() {
			((global::UnityEngine.EdgeCollider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineEdgeCollider2D.__set_name__SystemString__SystemVoid
		public void __596056203dcc74124c93920d2e5a48ba() {
			((global::UnityEngine.EdgeCollider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineEdgeCollider2D.__Reset__SystemVoid
		public void __d903df6f2ef411994813c8b0de53eb5d() {
			((global::UnityEngine.EdgeCollider2D)listenerTarget[listenerIdx]).Reset();
		}

		// UnityEngineBoxCollider2D.__set_name__SystemString__SystemVoid
		public void __cbc0473db95d25f77f831a44d042de55() {
			((global::UnityEngine.BoxCollider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineBoxCollider2D.__set_name__SystemString__SystemVoid
		public void __3a6ba99c2d4f450788408655114de653() {
			((global::UnityEngine.BoxCollider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEnginePolygonCollider2D.__set_name__SystemString__SystemVoid
		public void __976fe1b9246abea4452be1c2d9d92a44() {
			((global::UnityEngine.PolygonCollider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEnginePolygonCollider2D.__set_name__SystemString__SystemVoid
		public void __c00f2ba1ddae1ce424f2f76973d98d5d() {
			((global::UnityEngine.PolygonCollider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCompositeCollider2D.__set_name__SystemString__SystemVoid
		public void __e4a6ddf1b0b2d4c2a97f0eaa745f714d() {
			((global::UnityEngine.CompositeCollider2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCompositeCollider2D.__set_name__SystemString__SystemVoid
		public void __995ab6ed1f8ab080f8ac5f30aba77197() {
			((global::UnityEngine.CompositeCollider2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCompositeCollider2D.__GenerateGeometry__SystemVoid
		public void __7f0b6433c43a075e487d3a7a51ad7b8e() {
			((global::UnityEngine.CompositeCollider2D)listenerTarget[listenerIdx]).GenerateGeometry();
		}

		// UnityEngineJoint2D.__set_name__SystemString__SystemVoid
		public void __cd0e260274d8f7459db47d739cc428f0() {
			((global::UnityEngine.Joint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineJoint2D.__set_name__SystemString__SystemVoid
		public void __2337da8e38e40ac0556e34fb72079e67() {
			((global::UnityEngine.Joint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineDistanceJoint2D.__set_name__SystemString__SystemVoid
		public void __6eb424177ca67dede8f3384ae974b88e() {
			((global::UnityEngine.DistanceJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineDistanceJoint2D.__set_name__SystemString__SystemVoid
		public void __7010dc69f289171589512e22f46bd9ab() {
			((global::UnityEngine.DistanceJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineFrictionJoint2D.__set_name__SystemString__SystemVoid
		public void __5cd70b2f20193216bd4a787a8f4ed45b() {
			((global::UnityEngine.FrictionJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineFrictionJoint2D.__set_name__SystemString__SystemVoid
		public void __caf39170cd6eb7d8cf33faae1249cb08() {
			((global::UnityEngine.FrictionJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineHingeJoint2D.__set_name__SystemString__SystemVoid
		public void __4c3c06394c84d975abeb5f8a9d214eed() {
			((global::UnityEngine.HingeJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineHingeJoint2D.__set_name__SystemString__SystemVoid
		public void __d9ca87c12f977d130847cd277bf5bc13() {
			((global::UnityEngine.HingeJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineRelativeJoint2D.__set_name__SystemString__SystemVoid
		public void __061eafdd8724d2e66b47e0d6738c9fa4() {
			((global::UnityEngine.RelativeJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineRelativeJoint2D.__set_name__SystemString__SystemVoid
		public void __4c0c492f7d979a12cfce8c6597345b37() {
			((global::UnityEngine.RelativeJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSliderJoint2D.__set_name__SystemString__SystemVoid
		public void __5b1babaa26b50ed463c2413929614578() {
			((global::UnityEngine.SliderJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineSliderJoint2D.__set_name__SystemString__SystemVoid
		public void __8bd84fc7f78127449af4e55f53803bab() {
			((global::UnityEngine.SliderJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineTargetJoint2D.__set_name__SystemString__SystemVoid
		public void __f8f149e135e230a2995681ab201db958() {
			((global::UnityEngine.TargetJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineTargetJoint2D.__set_name__SystemString__SystemVoid
		public void __e81ef6b29757de1ff33a322d0b966ff8() {
			((global::UnityEngine.TargetJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineFixedJoint2D.__set_name__SystemString__SystemVoid
		public void __def84b0473b7554c28a0492d99b84aad() {
			((global::UnityEngine.FixedJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineFixedJoint2D.__set_name__SystemString__SystemVoid
		public void __0866f6fc4cb63f0896396854f297f2fa() {
			((global::UnityEngine.FixedJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineWheelJoint2D.__set_name__SystemString__SystemVoid
		public void __8086d9f6b120891982b5d53d732303f1() {
			((global::UnityEngine.WheelJoint2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineWheelJoint2D.__set_name__SystemString__SystemVoid
		public void __b0479d91ef564add82b060f76e811ef7() {
			((global::UnityEngine.WheelJoint2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineEffector2D.__set_name__SystemString__SystemVoid
		public void __b7985b90e4e8eed1760fc30622a84d6a() {
			((global::UnityEngine.Effector2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineEffector2D.__set_name__SystemString__SystemVoid
		public void __a4d92f1ee50194674a147594176ce1ff() {
			((global::UnityEngine.Effector2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineAreaEffector2D.__set_name__SystemString__SystemVoid
		public void __9aa6add1668eaa229324571871103fa6() {
			((global::UnityEngine.AreaEffector2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineAreaEffector2D.__set_name__SystemString__SystemVoid
		public void __c8839ee294ba9bf35896c3c371164948() {
			((global::UnityEngine.AreaEffector2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEnginePointEffector2D.__set_name__SystemString__SystemVoid
		public void __c2a568c06796de33a686d50b0df38743() {
			((global::UnityEngine.PointEffector2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEnginePointEffector2D.__set_name__SystemString__SystemVoid
		public void __7199dbfe45f0b0839e4cefe538c9f4ae() {
			((global::UnityEngine.PointEffector2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEnginePlatformEffector2D.__set_name__SystemString__SystemVoid
		public void __d9f0a9a6e9bcfe4e21c30116a69624a7() {
			((global::UnityEngine.PlatformEffector2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEnginePlatformEffector2D.__set_name__SystemString__SystemVoid
		public void __5f7b995dbbec81209385a7be994fa176() {
			((global::UnityEngine.PlatformEffector2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineSurfaceEffector2D.__set_name__SystemString__SystemVoid
		public void __11a5994c1483bfa1e78d9d1c1ddbeccd() {
			((global::UnityEngine.SurfaceEffector2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineSurfaceEffector2D.__set_name__SystemString__SystemVoid
		public void __559c73df519b7266ed445789bc6d2c14() {
			((global::UnityEngine.SurfaceEffector2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineConstantForce2D.__set_name__SystemString__SystemVoid
		public void __8b4ea982069e5e4e8a53d9aae0e0deea() {
			((global::UnityEngine.ConstantForce2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineConstantForce2D.__set_name__SystemString__SystemVoid
		public void __67a2b8efa9c7c1d75c6e8f64e1fd64e8() {
			((global::UnityEngine.ConstantForce2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCanvasGroup.__set_name__SystemString__SystemVoid
		public void __a3b5ddde830aaea78b6018fe8916936c() {
			((global::UnityEngine.CanvasGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCanvasGroup.__set_name__SystemString__SystemVoid
		public void __a94de7f8941b02d3eb48b13aeaad0b6c() {
			((global::UnityEngine.CanvasGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCanvasRenderer.__set_name__SystemString__SystemVoid
		public void __513b0f3a71ac3501876f49be9000a83c() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCanvasRenderer.__set_name__SystemString__SystemVoid
		public void __3f484bbb201e21d3803a86d323399f70() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCanvasRenderer.__DisableRectClipping__SystemVoid
		public void __e192fe5bba1773ee47edf1e340fb6e05() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).DisableRectClipping();
		}

		// UnityEngineCanvasRenderer.__SetTexture__UnityEngineTexture__SystemVoid.0
		public void __8e1fed5d5eb4b4a338ec6bf72b346cc0() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).SetTexture(
				(global::UnityEngine.Texture)listenerAsset
			);
		}

		// UnityEngineCanvasRenderer.__SetTexture__UnityEngineTexture__SystemVoid.1
		public void __5c49a59470b3d40ea6d8d394f01d06ff() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).SetTexture(
				(global::UnityEngine.Texture)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineCanvasRenderer.__SetAlphaTexture__UnityEngineTexture__SystemVoid.0
		public void __3726a55fec260b4abeac4b3e361ec62a() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).SetAlphaTexture(
				(global::UnityEngine.Texture)listenerAsset
			);
		}

		// UnityEngineCanvasRenderer.__SetAlphaTexture__UnityEngineTexture__SystemVoid.1
		public void __ed2304419dc8d80b2de4260c8befe3e5() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).SetAlphaTexture(
				(global::UnityEngine.Texture)listenerArgument[listenerIdx]
			);
		}

		// UnityEngineCanvasRenderer.__Clear__SystemVoid
		public void __0b5892a56f24b16509b44a33e571d1c2() {
			((global::UnityEngine.CanvasRenderer)listenerTarget[listenerIdx]).Clear();
		}

		// UnityEngineCanvas.__set_sortingLayerName__SystemString__SystemVoid
		public void __a844d202fd2dc88688ccbf750398c2ab() {
			((global::UnityEngine.Canvas)listenerTarget[listenerIdx]).sortingLayerName
				= listenerString;
		}

		// UnityEngineCanvas.__set_sortingLayerName__SystemString__SystemVoid
		public void __94969de6991f23fba6dd015178bcebb0() {
			((global::UnityEngine.Canvas)listenerTarget[listenerIdx]).sortingLayerName
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineCanvas.__set_name__SystemString__SystemVoid
		public void __8c743751db50e0f612398b9370cc0fae() {
			((global::UnityEngine.Canvas)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineCanvas.__set_name__SystemString__SystemVoid
		public void __a7c343bd3e9684bfb6dd82f71e2baaf2() {
			((global::UnityEngine.Canvas)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineWheelCollider.__set_name__SystemString__SystemVoid
		public void __1c1d8c37f3f0efcca101ae1ffe5887cc() {
			((global::UnityEngine.WheelCollider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineWheelCollider.__set_name__SystemString__SystemVoid
		public void __e0d77b8c1087e8441c87d9608ca4f95e() {
			((global::UnityEngine.WheelCollider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineWheelCollider.__ResetSprungMasses__SystemVoid
		public void __874dba1b1bbb4e14e87f1a687533ec97() {
			((global::UnityEngine.WheelCollider)listenerTarget[listenerIdx]).ResetSprungMasses();
		}

		// UnityEngineRenderingPostProcessingPostProcessVolume.__set_name__SystemString__SystemVoid
		public void __b080946d49582451131eda3b2fec4451() {
			((global::UnityEngine.Rendering.PostProcessing.PostProcessVolume)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineRenderingPostProcessingPostProcessVolume.__set_name__SystemString__SystemVoid
		public void __205f0353bcd9290d5f9be36ef3232e2e() {
			((global::UnityEngine.Rendering.PostProcessing.PostProcessVolume)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// TMProTextMeshPro.__set_text__SystemString__SystemVoid
		public void __4ffaabce56421b6989ef933e0ed16435() {
			((global::TMPro.TextMeshPro)listenerTarget[listenerIdx]).text
				= listenerString;
		}

		// TMProTextMeshPro.__set_text__SystemString__SystemVoid
		public void __ca224f7afd30ab0df3606ec76f2e8717() {
			((global::TMPro.TextMeshPro)listenerTarget[listenerIdx]).text
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// TMProTextMeshPro.__set_name__SystemString__SystemVoid
		public void __9f81c654cc35c6aad777c9e477dc6f05() {
			((global::TMPro.TextMeshPro)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// TMProTextMeshPro.__set_name__SystemString__SystemVoid
		public void __5b978c9653469ee5a7aae6bae78af19c() {
			((global::TMPro.TextMeshPro)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// TMProTextMeshProUGUI.__set_text__SystemString__SystemVoid
		public void __ffa6bf92c28762fcc59852ddb0635440() {
			((global::TMPro.TextMeshProUGUI)listenerTarget[listenerIdx]).text
				= listenerString;
		}

		// TMProTextMeshProUGUI.__set_text__SystemString__SystemVoid
		public void __eae435fdfdc928b939ea613acbfda628() {
			((global::TMPro.TextMeshProUGUI)listenerTarget[listenerIdx]).text
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// TMProTextMeshProUGUI.__set_name__SystemString__SystemVoid
		public void __a407e38d8fc91353c7dc60050c9c56a9() {
			((global::TMPro.TextMeshProUGUI)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// TMProTextMeshProUGUI.__set_name__SystemString__SystemVoid
		public void __fc2513d8a1a802bb132442409d66c825() {
			((global::TMPro.TextMeshProUGUI)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIButton.__set_name__SystemString__SystemVoid
		public void __6b5e98a80d95a0d55f4ace2106c9a58e() {
			((global::UnityEngine.UI.Button)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIButton.__set_name__SystemString__SystemVoid
		public void __c2fde925ca6634ccfc8828ca0bc4166e() {
			((global::UnityEngine.UI.Button)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIButton.__Select__SystemVoid
		public void __37ab4634d86cb20b424dc0fa4cb6af0c() {
			((global::UnityEngine.UI.Button)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUIDropdown.__set_name__SystemString__SystemVoid
		public void __1f296efe24d1ef6f1f4c55d950a52cca() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIDropdown.__set_name__SystemString__SystemVoid
		public void __2cfe1689019f6deb194b3566f26c9b46() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIDropdown.__RefreshShownValue__SystemVoid
		public void __3a9bf0f7ee4e113c6a5beaef9d06f609() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).RefreshShownValue();
		}

		// UnityEngineUIDropdown.__ClearOptions__SystemVoid
		public void __4be1e4ed7847a3d7db346135cd1be43c() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).ClearOptions();
		}

		// UnityEngineUIDropdown.__Show__SystemVoid
		public void __174935f8e905897107b366ae54c6fae0() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).Show();
		}

		// UnityEngineUIDropdown.__Hide__SystemVoid
		public void __536f15b84d0fabd2ed95baf3811b0539() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).Hide();
		}

		// UnityEngineUIDropdown.__Select__SystemVoid
		public void __cf8ae72401c7df9784e1990b4b6220ad() {
			((global::UnityEngine.UI.Dropdown)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUIGraphic.__set_name__SystemString__SystemVoid
		public void __872801a39023b9e0b7d6e48f2cdec2b4() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIGraphic.__set_name__SystemString__SystemVoid
		public void __2eed55f0398b25e363b7ab68c0de91c2() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIGraphic.__SetAllDirty__SystemVoid
		public void __ba5dadba9eb213d4db8f87b53eb657de() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).SetAllDirty();
		}

		// UnityEngineUIGraphic.__SetLayoutDirty__SystemVoid
		public void __dda5ffc2c60750f4292e3e72a17fcf3d() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).SetLayoutDirty();
		}

		// UnityEngineUIGraphic.__SetVerticesDirty__SystemVoid
		public void __d612b518685b800d31e14206c956a45c() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).SetVerticesDirty();
		}

		// UnityEngineUIGraphic.__SetMaterialDirty__SystemVoid
		public void __aef0039541a3440f07af059eabf2dca1() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).SetMaterialDirty();
		}

		// UnityEngineUIGraphic.__SetRaycastDirty__SystemVoid
		public void __d7c3df031859b4db3df4f6f15101f8f0() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).SetRaycastDirty();
		}

		// UnityEngineUIGraphic.__OnCullingChanged__SystemVoid
		public void __d8a67ccbf0b6b5ac6bc07935aa9f2c70() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).OnCullingChanged();
		}

		// UnityEngineUIGraphic.__LayoutComplete__SystemVoid
		public void __e9a223e7b69cb6b11ad0b30f9bb43f66() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIGraphic.__GraphicUpdateComplete__SystemVoid
		public void __5ab8edd3609fdf0a418c1a5299337e03() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIGraphic.__SetNativeSize__SystemVoid
		public void __2d9af7eb65e9ec56c9e283f072a07ea0() {
			((global::UnityEngine.UI.Graphic)listenerTarget[listenerIdx]).SetNativeSize();
		}

		// UnityEngineUIGraphicRaycaster.__set_name__SystemString__SystemVoid
		public void __eaae4edcfbabb1ff3c2f904246d9a0af() {
			((global::UnityEngine.UI.GraphicRaycaster)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIGraphicRaycaster.__set_name__SystemString__SystemVoid
		public void __0235d64880e2a94b9d6454167f424404() {
			((global::UnityEngine.UI.GraphicRaycaster)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIImage.__set_sprite__UnityEngineSprite__SystemVoid
		public void __d3db0632a565dd65651f78588d835401() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).sprite
				= (global::UnityEngine.Sprite)listenerAsset;
		}

		// UnityEngineUIImage.__set_sprite__UnityEngineSprite__SystemVoid
		public void __21b4ccaeb4aa25eb54603ae60545d476() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).sprite
				= (global::UnityEngine.Sprite)listenerArgument[listenerIdx];
		}

		// UnityEngineUIImage.__set_overrideSprite__UnityEngineSprite__SystemVoid
		public void __ea2309c7d5bd816b93bbddc4da6ae1b9() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).overrideSprite
				= (global::UnityEngine.Sprite)listenerAsset;
		}

		// UnityEngineUIImage.__set_overrideSprite__UnityEngineSprite__SystemVoid
		public void __c59ea936a8039d697a670d5829392ff4() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).overrideSprite
				= (global::UnityEngine.Sprite)listenerArgument[listenerIdx];
		}

		// UnityEngineUIImage.__set_name__SystemString__SystemVoid
		public void __05b5db2d0f185a4fc729a760f53c4765() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIImage.__set_name__SystemString__SystemVoid
		public void __ace2b71e71726320e5281f6989b7afc1() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIImage.__DisableSpriteOptimizations__SystemVoid
		public void __472df8bc068d24d2584ffb22cee87270() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).DisableSpriteOptimizations();
		}

		// UnityEngineUIImage.__OnBeforeSerialize__SystemVoid
		public void __497e17dcbb20ed38de955ca77da52987() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).OnBeforeSerialize();
		}

		// UnityEngineUIImage.__OnAfterDeserialize__SystemVoid
		public void __e12d72fd1211fb0b0e77692cf5c45948() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).OnAfterDeserialize();
		}

		// UnityEngineUIImage.__SetNativeSize__SystemVoid
		public void __f67c2d4c15a7f56c802ed5474b4dd780() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).SetNativeSize();
		}

		// UnityEngineUIImage.__CalculateLayoutInputHorizontal__SystemVoid
		public void __b1de507560c9fc0641cc122bf8630165() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIImage.__CalculateLayoutInputVertical__SystemVoid
		public void __e6cb8a15549e8c50044afce81de0246c() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIImage.__RecalculateClipping__SystemVoid
		public void __cc4df6f43bce102c7c1a8f10e49330e8() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).RecalculateClipping();
		}

		// UnityEngineUIImage.__RecalculateMasking__SystemVoid
		public void __efeb000fffcd64bcb0d158a115ca6119() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).RecalculateMasking();
		}

		// UnityEngineUIImage.__SetAllDirty__SystemVoid
		public void __900d4e89a386700c2e2fdce716f3b878() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).SetAllDirty();
		}

		// UnityEngineUIImage.__SetLayoutDirty__SystemVoid
		public void __92700211c8d76c54c4ea1ddb9b32ada2() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).SetLayoutDirty();
		}

		// UnityEngineUIImage.__SetVerticesDirty__SystemVoid
		public void __7d81881a2058aa085d3c512c9faa9515() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).SetVerticesDirty();
		}

		// UnityEngineUIImage.__SetMaterialDirty__SystemVoid
		public void __34bc6f1a8d747eac92cf4a4d3d84d124() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).SetMaterialDirty();
		}

		// UnityEngineUIImage.__SetRaycastDirty__SystemVoid
		public void __ba9df3b5f5aa7fc66616781647bfc3a5() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).SetRaycastDirty();
		}

		// UnityEngineUIImage.__OnCullingChanged__SystemVoid
		public void __64661ccdd6b5e608969fd50710b90fee() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).OnCullingChanged();
		}

		// UnityEngineUIImage.__LayoutComplete__SystemVoid
		public void __10d34f1043f2aed947fe9db503e5f13d() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIImage.__GraphicUpdateComplete__SystemVoid
		public void __ad654cfa10c72b430b9e56479f522112() {
			((global::UnityEngine.UI.Image)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIInputField.__set_text__SystemString__SystemVoid
		public void __9e9c55680c7562da84ab28fc4e9cdd5c() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).text
				= listenerString;
		}

		// UnityEngineUIInputField.__set_text__SystemString__SystemVoid
		public void __d6454b05a7b35771fd968844b3f53743() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).text
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIInputField.__set_name__SystemString__SystemVoid
		public void __08a7038dbfbecce3fcebee8a9fbcd716() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIInputField.__set_name__SystemString__SystemVoid
		public void __34af8e6bcf7852ae5b9b8fbdb4c3430a() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIInputField.__ForceLabelUpdate__SystemVoid
		public void __6431fa227505e8e2ca82cd65511e404c() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).ForceLabelUpdate();
		}

		// UnityEngineUIInputField.__LayoutComplete__SystemVoid
		public void __b9ab9ed59856270a768eebe15f2459f4() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIInputField.__GraphicUpdateComplete__SystemVoid
		public void __0c3fa61b7ff63fd5695415fd446dac39() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIInputField.__ActivateInputField__SystemVoid
		public void __29e72e5627d1a73a7deb497319e16651() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).ActivateInputField();
		}

		// UnityEngineUIInputField.__DeactivateInputField__SystemVoid
		public void __d1b482b56ebb592c080fac3d2f7924d4() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).DeactivateInputField();
		}

		// UnityEngineUIInputField.__CalculateLayoutInputHorizontal__SystemVoid
		public void __77447256a67da1053dab797389998e17() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIInputField.__CalculateLayoutInputVertical__SystemVoid
		public void __50332e2bf9379b1ae75e8b39b6cc1700() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIInputField.__Select__SystemVoid
		public void __077e35d3f706301448b22bb54030b0e6() {
			((global::UnityEngine.UI.InputField)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUIAspectRatioFitter.__set_name__SystemString__SystemVoid
		public void __e15d8c6944eed2ea98ebd6346d9f37fe() {
			((global::UnityEngine.UI.AspectRatioFitter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIAspectRatioFitter.__set_name__SystemString__SystemVoid
		public void __df24351ac6b566ec80c06c63155fbe05() {
			((global::UnityEngine.UI.AspectRatioFitter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIAspectRatioFitter.__SetLayoutHorizontal__SystemVoid
		public void __c04227f2c8b787d8eb0d648081a29750() {
			((global::UnityEngine.UI.AspectRatioFitter)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIAspectRatioFitter.__SetLayoutVertical__SystemVoid
		public void __f47a602d68282cc9e916eeb0fe316fe9() {
			((global::UnityEngine.UI.AspectRatioFitter)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUICanvasScaler.__set_name__SystemString__SystemVoid
		public void __1e946f24a9b7399593ca77502788cfca() {
			((global::UnityEngine.UI.CanvasScaler)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUICanvasScaler.__set_name__SystemString__SystemVoid
		public void __b4c3a9cdbeb1dbd9aaca1271d1fe814e() {
			((global::UnityEngine.UI.CanvasScaler)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIContentSizeFitter.__set_name__SystemString__SystemVoid
		public void __6cba71083ab653eb3a2ad86eb0e0c793() {
			((global::UnityEngine.UI.ContentSizeFitter)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIContentSizeFitter.__set_name__SystemString__SystemVoid
		public void __29d7538d3d831efa8d337965f379fb6f() {
			((global::UnityEngine.UI.ContentSizeFitter)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIContentSizeFitter.__SetLayoutHorizontal__SystemVoid
		public void __7a7de8110b0dd31416e8a4b1cba1bce9() {
			((global::UnityEngine.UI.ContentSizeFitter)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIContentSizeFitter.__SetLayoutVertical__SystemVoid
		public void __7a5a3a79fdcde9340a2021d26e7e210e() {
			((global::UnityEngine.UI.ContentSizeFitter)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUIGridLayoutGroup.__set_name__SystemString__SystemVoid
		public void __b3642878c3b44e21e70edf4c516dfdc5() {
			((global::UnityEngine.UI.GridLayoutGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIGridLayoutGroup.__set_name__SystemString__SystemVoid
		public void __65d6dcace5e27c4f9044b539c89f8872() {
			((global::UnityEngine.UI.GridLayoutGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIGridLayoutGroup.__CalculateLayoutInputHorizontal__SystemVoid
		public void __1151e963341ec0e225d33e6c4229ee46() {
			((global::UnityEngine.UI.GridLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIGridLayoutGroup.__CalculateLayoutInputVertical__SystemVoid
		public void __eaa9576eda44d439b5a3e5c864837b60() {
			((global::UnityEngine.UI.GridLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIGridLayoutGroup.__SetLayoutHorizontal__SystemVoid
		public void __bf72d84644c8615c2bebc3bdb07efe60() {
			((global::UnityEngine.UI.GridLayoutGroup)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIGridLayoutGroup.__SetLayoutVertical__SystemVoid
		public void __931f02665867b8bd5d05e09386dba7e3() {
			((global::UnityEngine.UI.GridLayoutGroup)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUIHorizontalLayoutGroup.__set_name__SystemString__SystemVoid
		public void __6793d696903225bf9335d2b03103e206() {
			((global::UnityEngine.UI.HorizontalLayoutGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIHorizontalLayoutGroup.__set_name__SystemString__SystemVoid
		public void __8a68b04656b3e7266b66e2c831ae14f1() {
			((global::UnityEngine.UI.HorizontalLayoutGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIHorizontalLayoutGroup.__CalculateLayoutInputHorizontal__SystemVoid
		public void __a67323c27544730b38b7ed5ce2279872() {
			((global::UnityEngine.UI.HorizontalLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIHorizontalLayoutGroup.__CalculateLayoutInputVertical__SystemVoid
		public void __e02ace47401cd59c5625690dea405f84() {
			((global::UnityEngine.UI.HorizontalLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIHorizontalLayoutGroup.__SetLayoutHorizontal__SystemVoid
		public void __d929df61a33b1fafc38978927b182690() {
			((global::UnityEngine.UI.HorizontalLayoutGroup)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIHorizontalLayoutGroup.__SetLayoutVertical__SystemVoid
		public void __d097d9d267a407ab91af9d9d299cc315() {
			((global::UnityEngine.UI.HorizontalLayoutGroup)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUIHorizontalOrVerticalLayoutGroup.__set_name__SystemString__SystemVoid
		public void __227d6c78a03e9acf9643de71dd9d9895() {
			((global::UnityEngine.UI.HorizontalOrVerticalLayoutGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIHorizontalOrVerticalLayoutGroup.__set_name__SystemString__SystemVoid
		public void __d93b83408544fa412c8bb73c48ea8895() {
			((global::UnityEngine.UI.HorizontalOrVerticalLayoutGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIHorizontalOrVerticalLayoutGroup.__CalculateLayoutInputHorizontal__SystemVoid
		public void __cca0b73f50e304de4883b0e06b01aeec() {
			((global::UnityEngine.UI.HorizontalOrVerticalLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIHorizontalOrVerticalLayoutGroup.__CalculateLayoutInputVertical__SystemVoid
		public void __70df8c91ba2f76c732e6057bca3b2db5() {
			((global::UnityEngine.UI.HorizontalOrVerticalLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIHorizontalOrVerticalLayoutGroup.__SetLayoutHorizontal__SystemVoid
		public void __f98b7a4301aa8e3bb1c1e6c5f1107035() {
			((global::UnityEngine.UI.HorizontalOrVerticalLayoutGroup)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIHorizontalOrVerticalLayoutGroup.__SetLayoutVertical__SystemVoid
		public void __caf652176561f87139c8c76b2c49a061() {
			((global::UnityEngine.UI.HorizontalOrVerticalLayoutGroup)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUILayoutElement.__set_name__SystemString__SystemVoid
		public void __1eed7196c82a6f1254908dd642f364b1() {
			((global::UnityEngine.UI.LayoutElement)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUILayoutElement.__set_name__SystemString__SystemVoid
		public void __6f4370528d21f1003e3873511a2362fe() {
			((global::UnityEngine.UI.LayoutElement)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUILayoutElement.__CalculateLayoutInputHorizontal__SystemVoid
		public void __7030c5a84f27c1e10fbfbe40df522fee() {
			((global::UnityEngine.UI.LayoutElement)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUILayoutElement.__CalculateLayoutInputVertical__SystemVoid
		public void __bc61df2db0ceeff23c89b1e533bd02fa() {
			((global::UnityEngine.UI.LayoutElement)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUILayoutGroup.__set_name__SystemString__SystemVoid
		public void __5e2d6b1bf23c9c93125dfd9410110866() {
			((global::UnityEngine.UI.LayoutGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUILayoutGroup.__set_name__SystemString__SystemVoid
		public void __de297e01ccda6f00716283a80af4b597() {
			((global::UnityEngine.UI.LayoutGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUILayoutGroup.__CalculateLayoutInputHorizontal__SystemVoid
		public void __82c76fd6710ec7ba13f30d353e64af89() {
			((global::UnityEngine.UI.LayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUILayoutGroup.__CalculateLayoutInputVertical__SystemVoid
		public void __5a95e85b8055ff2451c1df839e312ee8() {
			((global::UnityEngine.UI.LayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUILayoutGroup.__SetLayoutHorizontal__SystemVoid
		public void __bee18bffa923580f99c634a790abdf4c() {
			((global::UnityEngine.UI.LayoutGroup)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUILayoutGroup.__SetLayoutVertical__SystemVoid
		public void __2a3848e201724073359a521dc9216882() {
			((global::UnityEngine.UI.LayoutGroup)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUIVerticalLayoutGroup.__set_name__SystemString__SystemVoid
		public void __f64a5dc97df3724fb3cddc1b898f46cd() {
			((global::UnityEngine.UI.VerticalLayoutGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIVerticalLayoutGroup.__set_name__SystemString__SystemVoid
		public void __0851067cf398c2676e37251c4e87a143() {
			((global::UnityEngine.UI.VerticalLayoutGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIVerticalLayoutGroup.__CalculateLayoutInputHorizontal__SystemVoid
		public void __d45e7356174158235fd89b5d690fca83() {
			((global::UnityEngine.UI.VerticalLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIVerticalLayoutGroup.__CalculateLayoutInputVertical__SystemVoid
		public void __d0fdea53e04cacf8dae26286a2dc25e3() {
			((global::UnityEngine.UI.VerticalLayoutGroup)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIVerticalLayoutGroup.__SetLayoutHorizontal__SystemVoid
		public void __4894d8ef6ed9efb4c13bf1a645e47f32() {
			((global::UnityEngine.UI.VerticalLayoutGroup)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIVerticalLayoutGroup.__SetLayoutVertical__SystemVoid
		public void __1ea477cb3c6a2b110a988ad541b6d32c() {
			((global::UnityEngine.UI.VerticalLayoutGroup)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUIMask.__set_name__SystemString__SystemVoid
		public void __6fe20c6d209377a18778a740be1261d8() {
			((global::UnityEngine.UI.Mask)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIMask.__set_name__SystemString__SystemVoid
		public void __ed87a89a5bb94855d18a3b2e3b440418() {
			((global::UnityEngine.UI.Mask)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIMaskableGraphic.__set_name__SystemString__SystemVoid
		public void __a785a37574df1b87d937fd52a4705797() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIMaskableGraphic.__set_name__SystemString__SystemVoid
		public void __8ffbad9478dca519c11dfa028586c61c() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIMaskableGraphic.__RecalculateClipping__SystemVoid
		public void __56333abd700cba716d448c81fbbf9cf6() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).RecalculateClipping();
		}

		// UnityEngineUIMaskableGraphic.__RecalculateMasking__SystemVoid
		public void __52d2037307e1f1814985e939311f78f9() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).RecalculateMasking();
		}

		// UnityEngineUIMaskableGraphic.__SetAllDirty__SystemVoid
		public void __dc12c189a49ab0b319c4e5f96abee337() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).SetAllDirty();
		}

		// UnityEngineUIMaskableGraphic.__SetLayoutDirty__SystemVoid
		public void __a4bfa626606a1c457c91f837f8c55fcc() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).SetLayoutDirty();
		}

		// UnityEngineUIMaskableGraphic.__SetVerticesDirty__SystemVoid
		public void __4ae5d599224f16cdd10ab4eaddff5fb8() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).SetVerticesDirty();
		}

		// UnityEngineUIMaskableGraphic.__SetMaterialDirty__SystemVoid
		public void __115e83de3f246b08fc0657d9c7c62ed8() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).SetMaterialDirty();
		}

		// UnityEngineUIMaskableGraphic.__SetRaycastDirty__SystemVoid
		public void __ef604b2838d484a4d01e7a65d3ecbb85() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).SetRaycastDirty();
		}

		// UnityEngineUIMaskableGraphic.__OnCullingChanged__SystemVoid
		public void __27764f71f69bf747e83a85f15eee39e8() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).OnCullingChanged();
		}

		// UnityEngineUIMaskableGraphic.__LayoutComplete__SystemVoid
		public void __ca8daf167743bd2a32513b9687d7110d() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIMaskableGraphic.__GraphicUpdateComplete__SystemVoid
		public void __b5a10c58fb1dac7535e7adf46da93647() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIMaskableGraphic.__SetNativeSize__SystemVoid
		public void __a8088537c57ef7a931e8b64d214fa3e5() {
			((global::UnityEngine.UI.MaskableGraphic)listenerTarget[listenerIdx]).SetNativeSize();
		}

		// UnityEngineUIRawImage.__set_texture__UnityEngineTexture__SystemVoid
		public void __9bbe1f342dadad312207dd9e6610e3c4() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).texture
				= (global::UnityEngine.Texture)listenerAsset;
		}

		// UnityEngineUIRawImage.__set_texture__UnityEngineTexture__SystemVoid
		public void __0164bf1df87ca2511c754193a1dda86b() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).texture
				= (global::UnityEngine.Texture)listenerArgument[listenerIdx];
		}

		// UnityEngineUIRawImage.__set_name__SystemString__SystemVoid
		public void __33b131ff95f6b0bc59f1be03dbbe484b() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIRawImage.__set_name__SystemString__SystemVoid
		public void __8b205db4726398fd6b29c31cef8e2acd() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIRawImage.__SetNativeSize__SystemVoid
		public void __2abe2bde910a6dcc33ae6e994cb4ba1c() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).SetNativeSize();
		}

		// UnityEngineUIRawImage.__RecalculateClipping__SystemVoid
		public void __d30faa765e52b145a61a452c9d8f5882() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).RecalculateClipping();
		}

		// UnityEngineUIRawImage.__RecalculateMasking__SystemVoid
		public void __7c73730b298565c715b8c2cd1f0ae53c() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).RecalculateMasking();
		}

		// UnityEngineUIRawImage.__SetAllDirty__SystemVoid
		public void __b3a617e2e3b3ac9b0a6b25b92f18a1c2() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).SetAllDirty();
		}

		// UnityEngineUIRawImage.__SetLayoutDirty__SystemVoid
		public void __2d24a2464617f4e023417b2c32379d12() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).SetLayoutDirty();
		}

		// UnityEngineUIRawImage.__SetVerticesDirty__SystemVoid
		public void __8f0729b7dc8b88fe8603813c86285b33() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).SetVerticesDirty();
		}

		// UnityEngineUIRawImage.__SetMaterialDirty__SystemVoid
		public void __2812e9f0bb7d680096cc637223b088a1() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).SetMaterialDirty();
		}

		// UnityEngineUIRawImage.__SetRaycastDirty__SystemVoid
		public void __e76a20ecb782f61c0c59563819e89412() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).SetRaycastDirty();
		}

		// UnityEngineUIRawImage.__OnCullingChanged__SystemVoid
		public void __07be7e1ab9b9851a6970137d6c56ac20() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).OnCullingChanged();
		}

		// UnityEngineUIRawImage.__LayoutComplete__SystemVoid
		public void __08ec80d3c17c93f3efcf60b88b9b6afd() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIRawImage.__GraphicUpdateComplete__SystemVoid
		public void __6ab0c060114564f028eab7c14391a813() {
			((global::UnityEngine.UI.RawImage)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIRectMask2D.__set_name__SystemString__SystemVoid
		public void __fe570a839e9a15f6682b3f84eb0a8cc4() {
			((global::UnityEngine.UI.RectMask2D)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIRectMask2D.__set_name__SystemString__SystemVoid
		public void __e43587d5866ab65f5e8e79edf56bcd6e() {
			((global::UnityEngine.UI.RectMask2D)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIRectMask2D.__PerformClipping__SystemVoid
		public void __2e71c8845af1ba0315828f19423641d1() {
			((global::UnityEngine.UI.RectMask2D)listenerTarget[listenerIdx]).PerformClipping();
		}

		// UnityEngineUIRectMask2D.__UpdateClipSoftness__SystemVoid
		public void __9ba7c415881b51e144d37901d369d895() {
			((global::UnityEngine.UI.RectMask2D)listenerTarget[listenerIdx]).UpdateClipSoftness();
		}

		// UnityEngineUIScrollbar.__set_name__SystemString__SystemVoid
		public void __ba3594514e7ac1b71c9f069a21869d2c() {
			((global::UnityEngine.UI.Scrollbar)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIScrollbar.__set_name__SystemString__SystemVoid
		public void __ea3a09eb85ac3f4fdf365c09f4647488() {
			((global::UnityEngine.UI.Scrollbar)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIScrollbar.__LayoutComplete__SystemVoid
		public void __61f35613b50c343dfefed8b561889e83() {
			((global::UnityEngine.UI.Scrollbar)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIScrollbar.__GraphicUpdateComplete__SystemVoid
		public void __1c13ebe6bbd4eae51e589993dae704bc() {
			((global::UnityEngine.UI.Scrollbar)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIScrollbar.__Select__SystemVoid
		public void __5415f78ea7c6e30e564715fc84ab7f77() {
			((global::UnityEngine.UI.Scrollbar)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUIScrollRect.__set_name__SystemString__SystemVoid
		public void __7c40ce3668d18fbebcc3b652116a62e3() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIScrollRect.__set_name__SystemString__SystemVoid
		public void __3d27f9f507b4eedc18cc592c6ef1209a() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIScrollRect.__LayoutComplete__SystemVoid
		public void __d527d1f76d3d16bd3ed14e616d89e2fc() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIScrollRect.__GraphicUpdateComplete__SystemVoid
		public void __811d20aa514c5cc409dda32721932280() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIScrollRect.__StopMovement__SystemVoid
		public void __5ab1bf1c0b43b74e90b89768adca0cbc() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).StopMovement();
		}

		// UnityEngineUIScrollRect.__CalculateLayoutInputHorizontal__SystemVoid
		public void __fe0bf253d65190cd75b29acf77d6b67b() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIScrollRect.__CalculateLayoutInputVertical__SystemVoid
		public void __2f4ae23f4bc241190375ffed8370456a() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIScrollRect.__SetLayoutHorizontal__SystemVoid
		public void __6303c645b3551424438e44c4b34bc878() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).SetLayoutHorizontal();
		}

		// UnityEngineUIScrollRect.__SetLayoutVertical__SystemVoid
		public void __43e745ffebb74a63585592203b8469e0() {
			((global::UnityEngine.UI.ScrollRect)listenerTarget[listenerIdx]).SetLayoutVertical();
		}

		// UnityEngineUISelectable.__set_name__SystemString__SystemVoid
		public void __5d184c45ed144bfbce08680392047622() {
			((global::UnityEngine.UI.Selectable)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUISelectable.__set_name__SystemString__SystemVoid
		public void __d39ea36a14e4cab8da2b8ac37128dc8c() {
			((global::UnityEngine.UI.Selectable)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUISelectable.__Select__SystemVoid
		public void __9f225ff4ec6544b1a6ded094e6899dcd() {
			((global::UnityEngine.UI.Selectable)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUISlider.__set_name__SystemString__SystemVoid
		public void __63d32609489440d45da6bac13ee9e9ef() {
			((global::UnityEngine.UI.Slider)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUISlider.__set_name__SystemString__SystemVoid
		public void __3d863e1f2e44af339fb7efdbd1f06908() {
			((global::UnityEngine.UI.Slider)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUISlider.__LayoutComplete__SystemVoid
		public void __91e9aed6974b81349dbf467747646405() {
			((global::UnityEngine.UI.Slider)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUISlider.__GraphicUpdateComplete__SystemVoid
		public void __2f185ab13d528d779d41abb5b164a63d() {
			((global::UnityEngine.UI.Slider)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUISlider.__Select__SystemVoid
		public void __684b27793924b8db03a221c0f55c4f14() {
			((global::UnityEngine.UI.Slider)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUIText.__set_text__SystemString__SystemVoid
		public void __7685d7d8de2e7ed4893f40ab8e1de22a() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).text
				= listenerString;
		}

		// UnityEngineUIText.__set_text__SystemString__SystemVoid
		public void __3155ef4a1d205ee1fa95f584f71e5d16() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).text
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIText.__set_name__SystemString__SystemVoid
		public void __44d8133fe4d7854c654c6a34690104b6() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIText.__set_name__SystemString__SystemVoid
		public void __caa1fef1427bd2c410788508c812235d() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIText.__FontTextureChanged__SystemVoid
		public void __f5e622cb491d9c361a3302540e5b8374() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).FontTextureChanged();
		}

		// UnityEngineUIText.__CalculateLayoutInputHorizontal__SystemVoid
		public void __38cacb591b0cf69ae3047e0abcfa8c54() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).CalculateLayoutInputHorizontal();
		}

		// UnityEngineUIText.__CalculateLayoutInputVertical__SystemVoid
		public void __20627874b0e4547124ae3e9a9c2bc67d() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).CalculateLayoutInputVertical();
		}

		// UnityEngineUIText.__RecalculateClipping__SystemVoid
		public void __b721fe6a0af6be168c6bc8d0dece5281() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).RecalculateClipping();
		}

		// UnityEngineUIText.__RecalculateMasking__SystemVoid
		public void __f20f7b4218bae846333b64966022b0e9() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).RecalculateMasking();
		}

		// UnityEngineUIText.__SetAllDirty__SystemVoid
		public void __8829c5ea60d0c81ea2e7feec4ba06e55() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).SetAllDirty();
		}

		// UnityEngineUIText.__SetLayoutDirty__SystemVoid
		public void __cb045d8000accff4007d0aa812490ce7() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).SetLayoutDirty();
		}

		// UnityEngineUIText.__SetVerticesDirty__SystemVoid
		public void __2e4c4db8b60ad5bff190da63f90ae56a() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).SetVerticesDirty();
		}

		// UnityEngineUIText.__SetMaterialDirty__SystemVoid
		public void __405614fe472ce1565ec6ed71bb54db24() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).SetMaterialDirty();
		}

		// UnityEngineUIText.__SetRaycastDirty__SystemVoid
		public void __5db9cbadc0ba0e4bb5aac1a2ac9fdcda() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).SetRaycastDirty();
		}

		// UnityEngineUIText.__OnCullingChanged__SystemVoid
		public void __11e45dfd4d2de921dfaf9625125c9f9c() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).OnCullingChanged();
		}

		// UnityEngineUIText.__LayoutComplete__SystemVoid
		public void __04be6134a22e7bef326c9fce683b2985() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIText.__GraphicUpdateComplete__SystemVoid
		public void __6aa82f1404ba27eb14fead456bc8f5ec() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIText.__SetNativeSize__SystemVoid
		public void __3b32167574aac282a798d6dd2ef4601e() {
			((global::UnityEngine.UI.Text)listenerTarget[listenerIdx]).SetNativeSize();
		}

		// UnityEngineUIToggle.__set_name__SystemString__SystemVoid
		public void __4ba8e9c122a8d14fdadca333c8b963fd() {
			((global::UnityEngine.UI.Toggle)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIToggle.__set_name__SystemString__SystemVoid
		public void __b8e5dd0f48749454be0bfee6ac9599a9() {
			((global::UnityEngine.UI.Toggle)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIToggle.__LayoutComplete__SystemVoid
		public void __1e6fc92505ee9d5695000a81e93f0e44() {
			((global::UnityEngine.UI.Toggle)listenerTarget[listenerIdx]).LayoutComplete();
		}

		// UnityEngineUIToggle.__GraphicUpdateComplete__SystemVoid
		public void __2b65000967e5c3e42f3d8a9c50ee9687() {
			((global::UnityEngine.UI.Toggle)listenerTarget[listenerIdx]).GraphicUpdateComplete();
		}

		// UnityEngineUIToggle.__Select__SystemVoid
		public void __34ce3204d710638503eea2a72fb88702() {
			((global::UnityEngine.UI.Toggle)listenerTarget[listenerIdx]).Select();
		}

		// UnityEngineUIToggleGroup.__set_name__SystemString__SystemVoid
		public void __45c81889efd67add98e1254267c840fa() {
			((global::UnityEngine.UI.ToggleGroup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIToggleGroup.__set_name__SystemString__SystemVoid
		public void __a5553bbef4c1a2d3dffcc0a281cbda24() {
			((global::UnityEngine.UI.ToggleGroup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIToggleGroup.__EnsureValidState__SystemVoid
		public void __e747bbb548afe1d8b46dd0bb5a2db42d() {
			((global::UnityEngine.UI.ToggleGroup)listenerTarget[listenerIdx]).EnsureValidState();
		}

		// UnityEngineUIBaseMeshEffect.__set_name__SystemString__SystemVoid
		public void __e962a477668bb62eb21d3240713380c6() {
			((global::UnityEngine.UI.BaseMeshEffect)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIBaseMeshEffect.__set_name__SystemString__SystemVoid
		public void __d6269b96e25e1b92df701d621c73b356() {
			((global::UnityEngine.UI.BaseMeshEffect)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIOutline.__set_name__SystemString__SystemVoid
		public void __b403181b7176ee3b58476b6f587cbc7b() {
			((global::UnityEngine.UI.Outline)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIOutline.__set_name__SystemString__SystemVoid
		public void __646eca500f599a6cdcc0a8ad84d7ca53() {
			((global::UnityEngine.UI.Outline)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIPositionAsUV1.__set_name__SystemString__SystemVoid
		public void __47700e8ab2c9082f062fbe5ace9d7fa7() {
			((global::UnityEngine.UI.PositionAsUV1)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIPositionAsUV1.__set_name__SystemString__SystemVoid
		public void __8b53ae7f07643d03f2a8446a0ec447e9() {
			((global::UnityEngine.UI.PositionAsUV1)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// UnityEngineUIShadow.__set_name__SystemString__SystemVoid
		public void __aab1d4f589af0cdd4767ab1c6746a7f2() {
			((global::UnityEngine.UI.Shadow)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// UnityEngineUIShadow.__set_name__SystemString__SystemVoid
		public void __1a10357abae391a0aa27b0c2b93c6b1f() {
			((global::UnityEngine.UI.Shadow)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// CinemachineCinemachineDollyCart.__set_name__SystemString__SystemVoid
		public void __bafffda23df0096b3074881b5c0b8948() {
			((global::Cinemachine.CinemachineDollyCart)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// CinemachineCinemachineDollyCart.__set_name__SystemString__SystemVoid
		public void __37ef8488477241262e32d8564480c5c8() {
			((global::Cinemachine.CinemachineDollyCart)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// CinemachineCinemachineVirtualCamera.__set_name__SystemString__SystemVoid
		public void __616a0fa8bf096a98762a9b442ba47a8a() {
			((global::Cinemachine.CinemachineVirtualCamera)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// CinemachineCinemachineVirtualCamera.__set_name__SystemString__SystemVoid
		public void __adfb57503c37e665e4297de239a29cc1() {
			((global::Cinemachine.CinemachineVirtualCamera)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// CinemachineCinemachineVirtualCamera.__MoveToTopOfPrioritySubqueue__SystemVoid
		public void __51462db8611e5c5502a7ef06938d48d8() {
			((global::Cinemachine.CinemachineVirtualCamera)listenerTarget[listenerIdx]).MoveToTopOfPrioritySubqueue();
		}

		// VRCSDK3VideoComponentsBaseBaseVRCVideoPlayer.__set_name__SystemString__SystemVoid
		public void __de88b3f24dc449f9e8b5712b53dad7a8() {
			((global::VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3VideoComponentsBaseBaseVRCVideoPlayer.__set_name__SystemString__SystemVoid
		public void __bc22c9c99c7cbdeb7f3baae2e308c38e() {
			((global::VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3VideoComponentsBaseBaseVRCVideoPlayer.__Play__SystemVoid
		public void __a185a7e39fedcd7c12f459e458aee891() {
			((global::VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer)listenerTarget[listenerIdx]).Play();
		}

		// VRCSDK3VideoComponentsBaseBaseVRCVideoPlayer.__Pause__SystemVoid
		public void __74920ce688879745a55e245699f80ff4() {
			((global::VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer)listenerTarget[listenerIdx]).Pause();
		}

		// VRCSDK3VideoComponentsBaseBaseVRCVideoPlayer.__Stop__SystemVoid
		public void __0264cb1e6fc286aee7771de2fbd0ec31() {
			((global::VRC.SDK3.Video.Components.Base.BaseVRCVideoPlayer)listenerTarget[listenerIdx]).Stop();
		}

		// VRCSDK3MidiVRCMidiPlayer.__Play__SystemVoid
		public void __580dda3a3a8d9ebf58451548ea09b3de() {
			((global::VRC.SDK3.Midi.VRCMidiPlayer)listenerTarget[listenerIdx]).Play();
		}

		// VRCSDK3MidiVRCMidiPlayer.__Stop__SystemVoid
		public void __3631364d91944e049e251eb011a703ef() {
			((global::VRC.SDK3.Midi.VRCMidiPlayer)listenerTarget[listenerIdx]).Stop();
		}

		// VRCSDK3ComponentsVRCObjectPool.__set_name__SystemString__SystemVoid
		public void __93865d7bde8b72130273ee10d5aa6370() {
			((global::VRC.SDK3.Components.VRCObjectPool)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCObjectPool.__set_name__SystemString__SystemVoid
		public void __5d7f749c800da5c900477937f18a4999() {
			((global::VRC.SDK3.Components.VRCObjectPool)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3ComponentsVRCObjectPool.__Shuffle__SystemVoid
		public void __0c4e0f05769d73597e979ce16b61fbca() {
			((global::VRC.SDK3.Components.VRCObjectPool)listenerTarget[listenerIdx]).Shuffle();
		}

		// VRCSDK3ComponentsVRCAvatarPedestal.__set_name__SystemString__SystemVoid
		public void __5a94d97852b8a4c2366477ca2f9e5f3e() {
			((global::VRC.SDK3.Components.VRCAvatarPedestal)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCAvatarPedestal.__set_name__SystemString__SystemVoid
		public void __6f4c08a3a2a4051b88aec6f1c1e87361() {
			((global::VRC.SDK3.Components.VRCAvatarPedestal)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3ComponentsVRCAvatarPedestal.__SwitchAvatar__SystemString__SystemVoid.0
		public void __65f77615d745ee256d405135e91c0f28() {
			((global::VRC.SDK3.Components.VRCAvatarPedestal)listenerTarget[listenerIdx]).SwitchAvatar(
				listenerString
			);
		}

		// VRCSDK3ComponentsVRCAvatarPedestal.__SwitchAvatar__SystemString__SystemVoid.1
		public void __29be1dac56620546ed220af23e62005c() {
			((global::VRC.SDK3.Components.VRCAvatarPedestal)listenerTarget[listenerIdx]).SwitchAvatar(
				(global::System.String)listenerArgument[listenerIdx]
			);
		}

		// VRCSDK3ComponentsVRCObjectSync.__set_name__SystemString__SystemVoid
		public void __ce1bf46c1834574a45f33321b0c17ee3() {
			((global::VRC.SDK3.Components.VRCObjectSync)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCObjectSync.__set_name__SystemString__SystemVoid
		public void __32d60d9db00a07b71174db40f3ff4c13() {
			((global::VRC.SDK3.Components.VRCObjectSync)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3ComponentsVRCObjectSync.__FlagDiscontinuity__SystemVoid
		public void __94bb9b8c902d8a85b64666b95c5ba91b() {
			((global::VRC.SDK3.Components.VRCObjectSync)listenerTarget[listenerIdx]).FlagDiscontinuity();
		}

		// VRCSDK3ComponentsVRCObjectSync.__Respawn__SystemVoid
		public void __e1c95edd01721b32802bee17e2f10ea6() {
			((global::VRC.SDK3.Components.VRCObjectSync)listenerTarget[listenerIdx]).Respawn();
		}

		// VRCSDK3ComponentsVRCPickup.__set_name__SystemString__SystemVoid
		public void __f93a211780c5b9cd6c1d773f57f5e0b9() {
			((global::VRC.SDK3.Components.VRCPickup)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCPickup.__set_name__SystemString__SystemVoid
		public void __d0a95faa4069e0c4691fc2bde863850c() {
			((global::VRC.SDK3.Components.VRCPickup)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3ComponentsVRCPickup.__Drop__SystemVoid
		public void __e072de3cc728436c6b3d115bd9538e6b() {
			((global::VRC.SDK3.Components.VRCPickup)listenerTarget[listenerIdx]).Drop();
		}

		// VRCSDK3ComponentsVRCPickup.__PlayHaptics__SystemVoid
		public void __6c8fcade8e3ca7c3054425a9aa140a8c() {
			((global::VRC.SDK3.Components.VRCPickup)listenerTarget[listenerIdx]).PlayHaptics();
		}

		// VRCSDK3ComponentsVRCPortalMarker.__set_name__SystemString__SystemVoid
		public void __e2c1dc12c0b68176c418d674385eb179() {
			((global::VRC.SDK3.Components.VRCPortalMarker)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCPortalMarker.__set_name__SystemString__SystemVoid
		public void __434df1741d9d885bd590808c04dc1fff() {
			((global::VRC.SDK3.Components.VRCPortalMarker)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3ComponentsVRCPortalMarker.__RefreshPortal__SystemVoid
		public void __f883032f16e206db7b994f577def0b83() {
			((global::VRC.SDK3.Components.VRCPortalMarker)listenerTarget[listenerIdx]).RefreshPortal();
		}

		// VRCSDK3ComponentsVRCMirrorReflection.__set_name__SystemString__SystemVoid
		public void __1883320bae6a81e401f939f4789c84f1() {
			((global::VRC.SDK3.Components.VRCMirrorReflection)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCMirrorReflection.__set_name__SystemString__SystemVoid
		public void __a2b4334e85fc7888c2892e1a03fccefc() {
			((global::VRC.SDK3.Components.VRCMirrorReflection)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

		// VRCSDK3ComponentsVRCMirrorReflection.__OnWillRenderObject__SystemVoid
		public void __76626b8506a7c11bc64b7f23d47fe838() {
			((global::VRC.SDK3.Components.VRCMirrorReflection)listenerTarget[listenerIdx]).OnWillRenderObject();
		}

		// VRCSDK3ComponentsVRCStation.__set_name__SystemString__SystemVoid
		public void __bec0402cb83783af9971b90c4f0db363() {
			((global::VRC.SDK3.Components.VRCStation)listenerTarget[listenerIdx]).name
				= listenerString;
		}

		// VRCSDK3ComponentsVRCStation.__set_name__SystemString__SystemVoid
		public void __69caa20d8a9fb8a55442ce5196459300() {
			((global::VRC.SDK3.Components.VRCStation)listenerTarget[listenerIdx]).name
				= (global::System.String)listenerArgument[listenerIdx];
		}

	}
}

