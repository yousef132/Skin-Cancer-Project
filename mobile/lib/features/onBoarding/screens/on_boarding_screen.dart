import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:flutter_svg/svg.dart';
import 'package:mobile/config/routes/app_routes.dart';
import 'package:mobile/core/cach_helper/cach_helper.dart';
import 'package:mobile/core/helper/exetentions.dart';
import 'package:mobile/core/helper/spacing.dart';
import 'package:mobile/core/utils/string_manager.dart';
import 'package:mobile/core/widgets/app_button.dart';

import '../../../core/utils/text_styles.dart';

class OnBoardingScreen extends StatelessWidget {
  const OnBoardingScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SafeArea(
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            verticalSpacing(10),
            Container(
              height: 300.h,
              clipBehavior: Clip.antiAlias,
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(30),
                  image: const DecorationImage(
                      fit: BoxFit.cover,
                      image: AssetImage("assets/image/onboarding_2.jpg"))),
            ),
            verticalSpacing(10),
            Text(
              textAlign: TextAlign.center,
              StringManager.onboarding1,
              style: TextStyles.font20BlackW700,
            ),
            verticalSpacing(20),
            Text(
              textAlign: TextAlign.center,
              StringManager.onBoarding2,
              style: TextStyles.font14BlackW600,
            ),
            verticalSpacing(30),
            AppButton(
                buttonColor: const Color(0xFFC74587),
                width: 358,
                height: 60,
                buttonName: StringManager.getStarted,
                onTap: () {
                  CacheHelper.saveData(key: 'onBoarding', value: true);
                  context.pushReplacementNamed(Routes.choseUserRoutes);
                },
                textColor: Colors.white,
                white: false),
          ],
        ),
      ),
    ));
  }
}
